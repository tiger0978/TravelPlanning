using CSV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點規劃.Components;
using 旅遊景點規劃.Events;
using 旅遊景點規劃.Models;

namespace 旅遊景點規劃
{
    public partial class TravelPlan : Form
    {
        private CreateTravelPlan lastForm = null;
        private TravelInfoService travelInfoService = new TravelInfoService(ConfigurationManager.AppSettings["rootPath"], "旅遊總覽.csv");

        public TravelPlan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lastForm!=null)
            {
                lastForm.Close();
            }
            CreateTravelPlan createTravelPlan = new CreateTravelPlan();
            createTravelPlan.Show();
            lastForm = createTravelPlan;
        }

        private void TravelPlan_Load(object sender, EventArgs e)
        {
            PlaceEvent.SaveTravelSchedule += RenderTravelPlan;
            RenderTravelPlan();
        }

        private void RemoveTravelInfo(object sender, TravelInfo travelInfo)
        {
            var temp = (Control)sender;
            temp.Dispose();
            flowLayoutPanel1.Controls.Remove(temp);
            GC.Collect();
        }
        private void RenderTravelPlan(object sender = null, EventArgs e = null)
        {
            flowLayoutPanel1.Controls.Clear();
            List<TravelPlanInfo> travelPlanInfos = travelInfoService.ReadTravelInfos();
            foreach (TravelPlanInfo travelPlanInfo in travelPlanInfos)
            {
                TravelInfo travelInfo = new TravelInfo(travelPlanInfo, travelPlanInfos);
                travelInfo.RemoveItem += RemoveTravelInfo;
                flowLayoutPanel1.Controls.Add(travelInfo);
            }
        }
    }
}
