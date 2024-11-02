using CSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點規劃.Models;

namespace 旅遊景點規劃.Components
{
    public partial class TravelInfo : UserControl
    {
        TravelPlanInfo travelPlanInfo;
        TravelInfoService travelInfoService;
        List<TravelPlanInfo> travelPlanInfos;
        string deleteImgPath = @"C:\Users\user\source\repos\旅遊景點規劃\icon\trashcan.png";
        CSVHelper csvHelper = new CSVHelper(ConfigurationManager.AppSettings["rootPath"]);
        public event EventHandler<TravelInfo> RemoveItem;
        public TravelInfo(TravelPlanInfo travelPlanInfo, List<TravelPlanInfo> travelPlanInfos)
        {
            InitializeComponent();
            delete.Image = Image.FromFile(deleteImgPath);
            this.travelPlanInfo = travelPlanInfo;
            this.travelInfoService = new TravelInfoService(ConfigurationManager.AppSettings["rootPath"], $"{travelPlanInfo.title}_{travelPlanInfo.travelId}\\{travelPlanInfo.title}.json");
            this.travelPlanInfos = travelPlanInfos;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            title.Text = travelPlanInfo.title;

            Image image = new Bitmap(travelPlanInfo.imagePath);
            pictureBox1.Image = image;
        }

        private void click_OpenTravelDetail(object sender, EventArgs e)
        {
            List<TravelPageInfo> travelPageInfos = travelInfoService.ReadFile();
            TravelSchedule travelSchedule = new TravelSchedule(travelPageInfos,travelPlanInfo);
            travelSchedule.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否要刪除該行程?","Warning",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = null;
                RemoveItem.Invoke(this,null);
                GC.Collect();
                Thread.Sleep(500); // 增加延遲，避免記憶體未回收乾淨就進行資料夾刪除，導致錯誤
                string dir_path = Path.Combine(ConfigurationManager.AppSettings["rootPath"], $"{travelPlanInfo.title}_{travelPlanInfo.travelId}");
                if (Directory.Exists(dir_path)) 
                {
                    Directory.Delete(dir_path, true);
                }
                travelPlanInfos.Remove(travelPlanInfo);
                string csv_path = Path.Combine(ConfigurationManager.AppSettings["rootPath"], "旅遊總覽.csv");
                if (File.Exists(csv_path))
                {
                    File.Delete(csv_path);
                }
                csvHelper.WriteToCSV("旅遊總覽.csv", travelPlanInfos);
            }
        }
    }
}
