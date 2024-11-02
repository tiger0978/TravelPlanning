using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊景點規劃.Models
{
    public class TravelPlanInfo
    {
        public string title {  get; set; }
        public int travelDays { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public string imagePath { get; set; }
        public Guid travelId { get; set; }
        public TravelPlanInfo (string title, int travelDays, DateTime startDate, string imagePath)
        {
            travelId = Guid.NewGuid();
            this.title = title;
            this.travelDays = travelDays;
            this.StartDate = startDate;
            this.EndDate = startDate.AddDays(travelDays);
            this.imagePath = imagePath;
        }
        public TravelPlanInfo() { 
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
    }
}
