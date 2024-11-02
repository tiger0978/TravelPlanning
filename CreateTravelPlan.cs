using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點規劃.Components;
using 旅遊景點規劃.Models;

namespace 旅遊景點規劃
{
    public partial class CreateTravelPlan : Form
    {
        private string imgPath = @"C:\Users\user\Downloads\images.png";
        private TravelSchedule lastForm = null;
        public CreateTravelPlan()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(imgPath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            int.TryParse(textBox2.Text, out int travelDays);
            if(travelDays ==0)
            {
                MessageBox.Show("天數不得為空或是0!");
                return;
            }
            DateTime startDate =  dateTimePicker1.Value.Date;

            TravelPlanInfo travelPlanInfo = new TravelPlanInfo(title, travelDays, startDate, imgPath); 
            List<TravelPageInfo> travelPageInfos = new List<TravelPageInfo>();  

            for (int i = 0; i < travelDays; i++)
            {
                TravelPageInfo travelPage = new TravelPageInfo();
                for (int j = 0; j < 2; j++)
                {
                    DailyTravelInfo dailyTravel = new DailyTravelInfo();
                    travelPage.placeDetails.Add(dailyTravel);
                }
                travelPageInfos.Add(travelPage);
            }

            if (lastForm != null)
            {
                lastForm.Close();
            }
            TravelSchedule travelSchedule  = new TravelSchedule(travelPageInfos,travelPlanInfo);
            pictureBox1.Image = null;
            this.Dispose();
            this.Close();
            travelSchedule.Show();
            lastForm = travelSchedule;
            GC.Collect();
            string dircPath = Path.Combine(ConfigurationManager.AppSettings["rootPath"], $"{travelPlanInfo.title}_{travelPlanInfo.travelId}");
            if (!Directory.Exists(dircPath))
            {
                Directory.CreateDirectory(dircPath);
            }
        }

        private void CreateTravelPlan_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string path = "C:\\Users\\user\\Downloads";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "PNG|*.png|JPG|*.jpg|Gif|*.gif";
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string imgPath = openFileDialog.FileName;
                this.imgPath = imgPath;
                pictureBox1.Image = Image.FromFile(imgPath);
            }
        }

        private void travelInfo1_Load(object sender, EventArgs e)
        {

        }
    }
}
