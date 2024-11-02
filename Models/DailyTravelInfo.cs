using GoogleMapAPI.Places.PlaceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 旅遊景點規劃.Attributes;

namespace 旅遊景點規劃.Models
{
    public class DailyTravelInfo 
    {
        [BookMark("")]
        public PlaceDetailResponse placeDetail { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public DailyTravelInfo(PlaceDetailResponse placeDetail,DateTime startTime, DateTime endTime)
        {
            this.placeDetail = placeDetail;
            this.startTime = startTime;
            this.endTime = endTime;
        }
        public DailyTravelInfo() { }
        
    }
}
