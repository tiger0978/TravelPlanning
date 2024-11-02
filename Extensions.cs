using GMap.NET.MapProviders;
using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點規劃.Components;
using 旅遊景點規劃.Models;
using static System.Windows.Forms.Control;

namespace 旅遊景點規劃
{
    public static class Extensions
    {
        public static void SetUpTabControl(this TabControl tabControl)
        {
            tabControl.Location = new Point(23, 29);
            tabControl.Name = "tabControl1";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(340, 800);
            tabControl.TabIndex = 1;
            tabControl.ItemSize = new Size(30, 45);
            tabControl.Font = new Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
        }
        public static void SetUpTabPage(this TabPage tabPage,TravelPlanInfo planInfo, int days)
        {
            tabPage.AutoScroll = true;
            tabPage.Location = new Point(4, 25);
            tabPage.Padding = new Padding(3);
            tabPage.Size = new Size(340, 800);
            tabPage.Text = planInfo.StartDate.AddDays(days).ToString("MM/dd\r\n(dddd)");
            tabPage.UseVisualStyleBackColor = true;
        }
        public static void SetUpFlowLayoutPanel(this FlowLayoutPanel flowLayoutPanel) 
        {
            flowLayoutPanel.Size = new Size(340, 800);
            flowLayoutPanel.TabIndex = 0;
            flowLayoutPanel.AutoScroll = true;
        }
        public static void SetUpTravelScheduleBox(this TravelScheduleBox travelScheduleBox, int width) 
        {
            travelScheduleBox.BackColor = SystemColors.ButtonFace;
            travelScheduleBox.Width = width;
        }
        public static void Initialize(this GMapControl gMapControl)
        {
            gMapControl.MapProvider = GoogleMapProvider.Instance; // 設置地圖源
            GMaps.Instance.Mode = AccessMode.ServerAndCache; // GMap工作模式
            gMapControl.Position = new PointLatLng(25.22073181939088, 121.56732774228881);
            gMapControl.MaxZoom = 20;
            gMapControl.Zoom = 14;
            gMapControl.ShowCenter = false;
        }
        public static void SwitchGMapView (this GMapControl gMapControl,double lat, double lng)
        {
            gMapControl.Zoom = 12;
            gMapControl.Position = new PointLatLng(lat, lng);
            gMapControl.Zoom = 16;
            gMapControl.ShowCenter = true;
        }

        public static IEnumerable<Control> ToList(this ControlCollection control)
        {
            foreach (Control item in control)
            {

                yield return item;
            }
        }
    }
}
