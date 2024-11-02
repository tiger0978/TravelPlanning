using GMap.NET;
using GMap.NET.MapProviders;
using GoogleMapAPI.Common.Enums;
using GoogleMapAPI.Directions.Direction;
using GoogleMapAPI.Directions;
using GoogleMapAPI.Places.PlaceDetail;
using GoogleMapAPI.Utility;
using GoogleMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點規劃.Components;
using 旅遊景點規劃.Models;
using GMap.NET.WindowsForms;
using 旅遊景點規劃.Events;
using static GoogleMapAPI.Places.PlaceDetail.PlaceDetailResponse;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;

namespace 旅遊景點規劃
{
    public partial class TravelSchedule : Form
    {
        private TravelPlanInfo planInfo;
        TabControl tabControl;
        TravelInfoService travelInfoService = new TravelInfoService(ConfigurationManager.AppSettings["rootPath"], "旅遊總覽.csv");
        private List<PointLatLng> points = new List<PointLatLng>();

        public TravelSchedule(List<TravelPageInfo> travelPageInfos, TravelPlanInfo travelPlanInfo) 
        {
            InitializeComponent();
            gMapControl1.Initialize();
            planInfo = travelPlanInfo;
            TravelScheduleService.travelPageInfos = travelPageInfos;
            PlaceEvent.SelectedPlace += RecievedPlaceDetail;
            CreateDaysPage(travelPageInfos);
            tabControl.SelectedIndexChanged += SelectedTabPage;
            RenderTabPage(TravelScheduleService.GetPlaceDetails(0), tabControl.TabPages[0]); 
        }

        private void CreateDaysPage(List<TravelPageInfo> travelPageInfos) // 根據旅遊天數建立 tabpage 
        {
            tabControl = new TabControl();
            tabControl.SetUpTabControl();
            tabControl.SelectedIndexChanged += new System.EventHandler(tabControl_SelectedIndexChanged);
            flowLayoutPanel1.Controls.Add(tabControl);
            TravelScheduleService.travelPageInfos = travelPageInfos;

            for (int i = 0; i < travelPageInfos.Count; i++)
            {
                TabPage tabPage = new TabPage();
                tabPage.ContextMenuStrip = contextMenuStrip1;
                tabPage.SetUpTabPage(planInfo, i);
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                flowLayoutPanel.SetUpFlowLayoutPanel();
                tabPage.Controls.Add(flowLayoutPanel);
                tabControl.Controls.Add(tabPage);
            }
        }
        private void SelectedTabPage(object sender, EventArgs e)
        {
            SelectedDays(TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex));
        }
        private void SelectedDays(List<DailyTravelInfo> dailyTravelInfos)
        {
            TabPage tabPage = tabControl.SelectedTab;
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)tabPage.Controls[0];
            flowLayoutPanel.Controls.Clear();
            if(dailyTravelInfos.Count == 0)
            {
                AddSchedulBoxItem(flowLayoutPanel, "起點", tabPage.Width, false, 0);
                AddSchedulBoxItem(flowLayoutPanel, "終點", tabPage.Width, false, 1);
                return;
            }
            RenderTabPage(dailyTravelInfos, tabPage);
        }

        private void AddSchedulBoxItem(FlowLayoutPanel flowLayoutPanel, string title, int width, bool IsDelete, int index, DailyTravelInfo dailyTravelInfo = null)
        {
            TravelScheduleBox scheduleBox = new TravelScheduleBox(title, IsDelete);
            scheduleBox.Tag = index;
            scheduleBox.Click += Place_Click;
            scheduleBox.RemoveItem += TravelScheduleBox_RemoveItem;
            scheduleBox.SetUpTravelScheduleBox(width);
            if (dailyTravelInfo?.placeDetail != null)
            {
                scheduleBox.dateTimePicker1.Value = dailyTravelInfo.startTime;
                scheduleBox.dateTimePicker2.Value = dailyTravelInfo.endTime;
                scheduleBox.placeDetail = dailyTravelInfo?.placeDetail;
                scheduleBox.autoCompleteTextBox1.Text = dailyTravelInfo.placeDetail.result.name != null ? dailyTravelInfo.placeDetail.result.name : "";
            }
            flowLayoutPanel.Controls.Add(scheduleBox);
        }

        private void RenderTabPage(List<DailyTravelInfo> dailyTravelInfos, TabPage tabPage)
        {
            FlowLayoutPanel panel = (FlowLayoutPanel)tabControl.SelectedTab.Controls[0];
            panel.Controls.Clear();
            for (int i = 0; i < dailyTravelInfos.Count; i++)
            {
                (string groupName, bool isDelete) = TravelScheduleService.GetScheduleBoxType(i, dailyTravelInfos.Count);
                AddSchedulBoxItem(panel, groupName, tabPage.Width, isDelete,i, dailyTravelInfos[i]);
            }
        }
        private void TravelScheduleBox_RemoveItem(object sender, EventArgs e)
        {
            TravelScheduleBox box = (TravelScheduleBox)sender;
            int index = (int)box.Tag;
            TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex).RemoveAt(index);
            RenderTabPage(TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex), tabControl.SelectedTab);
            radioButton4.Enabled = tabControl.SelectedTab.Controls[0].Controls.Count <= 2 ? true : false;
        }

        private void Place_Click(object sender, EventArgs e)
        {
            TravelScheduleBox travelScheduleBox = ((GroupBox)sender).Tag as TravelScheduleBox;
            CreatePlaceInfo(travelScheduleBox.placeDetail);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tabPage = tabControl.SelectedTab;
            int travelBoxCount = TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex).Count;
            if (travelBoxCount == 7)
            {
                MessageBox.Show("超過行程數目");
                return;
            }
            DailyTravelInfo dailyTravelInfo = new DailyTravelInfo();
            TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex).Insert(travelBoxCount-1, dailyTravelInfo);
            RenderTabPage(TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex), tabPage);
            radioButton4.Enabled = travelBoxCount <= 2 ? true : false;
        }

        private async void Check_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)tabControl.SelectedTab.Controls[0];
            foreach (TravelScheduleBox travelBox in flowLayoutPanel.Controls)
            {
                if (travelBox.autoCompleteTextBox1.Text == "")
                {
                    MessageBox.Show("必須填入地點");
                    return;
                }
            }

            GetAllScheduleInfo();
            gMapControl1.CreateMarker(tabControl.SelectedTab.Text, points);

            Mode mode = (Mode)int.Parse(groupBox1.Controls.ToList().FirstOrDefault(x => ((RadioButton)x).Checked).Tag.ToString());
            List<Avoid>  avoids = groupBox2.Controls.ToList().Where(x => ((CheckBox)x).Checked == true).Select(x => (Avoid)int.Parse(((CheckBox)x).Tag.ToString())).ToList();

            var latLngs = await TravelScheduleService.GetPointLatLngs(tabControl.SelectedIndex, avoids, mode);
            gMapControl1.CreateRoute($"Route_{planInfo.title}", latLngs);
            gMapControl1.SwitchGMapView(points[0].Lat, points[0].Lng);
            gMapControl1.Zoom = 13;
            gMapControl1.ToImage();
            Image image = gMapControl1.ToImage();
            string dircPath = Path.Combine(ConfigurationManager.AppSettings["rootPath"], $"{planInfo.title}_{planInfo.travelId}");
            if (!Directory.Exists(dircPath))
            {
                Directory.CreateDirectory(dircPath);
            }
            string imgPath = Path.Combine(dircPath, $"route_{tabControl.SelectedIndex}.jpg");
            image.Save(imgPath);
            TravelScheduleService.travelPageInfos[tabControl.SelectedIndex].googlemapShot = imgPath;
        }

        private void RecievedPlaceDetail(object sender, DailyTravelInfo dailyTravelInfo)
        {
            CreatePlaceInfo(dailyTravelInfo.placeDetail); //當 autocompletetextbox 輸入資訊後建立右方資訊欄
            TravelScheduleBox travelbox = (TravelScheduleBox)sender;
            int index = (int)travelbox.Tag;
            var dailyInfos = TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex);
            if (dailyInfos.Count <= index)
            {
                dailyInfos.Add(dailyTravelInfo);
                return;
            }
            TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex)[index] = dailyTravelInfo;
        }

        private void gMapControl1_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            int Index = (int)item.Tag;
            PlaceDetailResponse placeDetail = TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex)[Index].placeDetail;
            CreatePlaceInfo(placeDetail);
        }
        private void CreatePlaceInfo(PlaceDetailResponse placeDetail)
        {
            if(placeDetail == null)
            {
                return;
            }
            gMapControl1.SwitchGMapView(placeDetail.result.geometry.location.lat, placeDetail.result.geometry.location.lng);
            flowLayoutPanel2.Controls.Clear();
            PictureBoxes pictureBoxes = new PictureBoxes(placeDetail);
            flowLayoutPanel2.Controls.Add(pictureBoxes);
            PlaceInfo placeInfo = new PlaceInfo(placeDetail);
            flowLayoutPanel2.Controls.Add(placeInfo);
            if (placeDetail.result.reviews == null)
            {
                return;
            }
            foreach (Review review in placeDetail.result.reviews)
            {
                Comments comment = new Comments(review);
                flowLayoutPanel2.Controls.Add(comment);
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //把 GmapControl 圖層內容清除乾淨
            gMapControl1.ClearOverLay(); 
        }
        private void Save_Click(object sender, EventArgs e) //將所有旅遊行程轉成 Json 字串並存至 txt  
        {
            travelInfoService.SaveJSONFile(tabControl, planInfo);
            if (!travelInfoService.CheckDataExisted(planInfo))
            {
                travelInfoService.SaveAllInfoCSV(planInfo);
            }
            PlaceEvent.RenderTravelPlan();
            MessageBox.Show("已將行程資訊存檔!");
        }
        private void GetAllScheduleInfo()
        {
            points.Clear();
            for (int i = 0; i< tabControl.TabCount; i++) 
            {
                TravelScheduleService.GetPlaceDetails(i).Clear();
                TabPage tabPage = tabControl.TabPages[i];
                FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)tabPage.Controls[0];
                foreach (TravelScheduleBox travelBox in flowLayoutPanel.Controls)
                {
                    PlaceDetailResponse placeDetail = travelBox.placeDetail;
                    TravelScheduleService.GetPlaceDetails(i).Add(new DailyTravelInfo(placeDetail, travelBox.dateTimePicker1.Value, travelBox.dateTimePicker2.Value));
                }
            }
            points = TravelScheduleService.GetPlaceDetails(tabControl.SelectedIndex).Select(x => new PointLatLng()
            {
                Lat = x.placeDetail.result.geometry.location.lat,
                Lng = x.placeDetail.result.geometry.location.lng
            }).ToList();
        }

        private void TakeShot_Click(object sender, EventArgs e)
        {
            gMapControl1.SwitchGMapView(points[0].Lat, points[0].Lng);
            gMapControl1.Zoom = 13;
            gMapControl1.ToImage();
            Image image = gMapControl1.ToImage();
            string dircPath = Path.Combine(ConfigurationManager.AppSettings["rootPath"], $"{planInfo.title}_{planInfo.travelId}");
            if (!Directory.Exists(dircPath))
            {
                Directory.CreateDirectory(dircPath);
            }
            string imgPath = Path.Combine(dircPath, $"route_{tabControl.SelectedIndex}.jpg");
            image.Save(imgPath);
            TravelScheduleService.travelPageInfos[tabControl.SelectedIndex].googlemapShot = imgPath;
        }

        private void Export_Click(object sender, EventArgs e)
        {

            ExportService exportService = new ExportService();
            exportService.ExportFile(TravelScheduleService.travelPageInfos, planInfo);
            MessageBox.Show("行程資訊匯出成功!","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }
    }
}
