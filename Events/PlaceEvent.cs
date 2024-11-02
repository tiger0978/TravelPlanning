using GoogleMapAPI.Places.PlaceDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 旅遊景點規劃.Models;

namespace 旅遊景點規劃.Events
{
    public static class PlaceEvent
    {
        public static event EventHandler<DailyTravelInfo> SelectedPlace;
        public static event EventHandler SaveTravelSchedule;

        public static void SelectedPlaceNotify(object obj, DailyTravelInfo dailyTravelInfo)
        {
            SelectedPlace.Invoke(obj, dailyTravelInfo);
        }
        public static void RenderTravelPlan() 
        {
            SaveTravelSchedule.Invoke(null,null);
        }
    }
}
