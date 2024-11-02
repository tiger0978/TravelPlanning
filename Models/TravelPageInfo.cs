using GoogleMapAPI.Places.PlaceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點規劃.Models
{
    public class TravelPageInfo
    {
        public List<DailyTravelInfo> placeDetails = new List<DailyTravelInfo>();

        public string googlemapShot;
    }
}
