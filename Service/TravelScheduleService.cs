using GMap.NET;
using GoogleMapAPI.Common.Enums;
using GoogleMapAPI.Directions.Direction;
using GoogleMapAPI.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 旅遊景點規劃.Components;
using 旅遊景點規劃.Models;
using GoogleMapAPI.Utility;
using System.Collections;

namespace 旅遊景點規劃
{
    public class TravelScheduleService
    {
        public static List<TravelPageInfo> travelPageInfos;

        public static List<DailyTravelInfo> GetPlaceDetails(int index)
        {

            return travelPageInfos[index].placeDetails;
        }


        public static (string, bool) GetScheduleBoxType(int index, int travelInfoCount)
        {
            string groupName = "中繼點";
            bool isDelete = true;
            if (index == 0)
            {
                groupName = "起點";
                isDelete = false;
            }
            else if (index == travelInfoCount - 1)
            {
                groupName = "終點";
                isDelete = false;
            }
            return (groupName, isDelete);
        }
        public static string GetWayPoint(List<DailyTravelInfo> placeDetails)
        {
            string wayPoints = "";
            if (placeDetails.Count > 2)
            {
                List<string> wayPointIds = placeDetails.Skip(1).Take(placeDetails.Count - 2).Select(x => x.placeDetail.result.place_id).ToList();
                foreach (string wayPointId in wayPointIds)
                {
                    wayPoints += "place_id:" + wayPointId + "|";
                }
            }
            return wayPoints;
        }

        public static async Task<IEnumerable<List<PointLatLng>>> GetPointLatLngs(int index, List<Avoid> avoids, Mode mode)
        {
            string originPlaceId = "place_id:" + travelPageInfos[index].placeDetails.First().placeDetail.result.place_id;
            string destinationPlaceId = "place_id:" + travelPageInfos[index].placeDetails.Last().placeDetail.result.place_id;
            string wayPoints = GetWayPoint(travelPageInfos[index].placeDetails);
            DirectionResponse directionResponse = await DirectionService.Direction(originPlaceId, destinationPlaceId, avoids, mode, wayPoints);
            var latalngs = directionResponse.routes.Select(x => PolylineEncoder.Decode(x.overview_polyline.points).ToList()).ToList();

            return latalngs;
        }
    }
}
