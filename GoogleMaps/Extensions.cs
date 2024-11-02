using GMap.NET;
using GMap.NET.WindowsForms;
using GoogleMapAPI.Utility;
using GoogleMaps.OverLays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps
{
    public static class Extensions
    {
        public static GMapOverlay CreateRoute(this GMapControl gMapControl, string overLayId, IEnumerable<PointLatLng> points, GMapToolTip toolTip = null)
        {
            AMapOverlay routeOverLay = new GoogleMapRoute(gMapControl);
            GMapOverlay gMapOverlay = routeOverLay.SetOverLay(overLayId, points, toolTip);
            return gMapOverlay;
        }
        public static GMapOverlay CreateRoute(this GMapControl gMapControl, string overLayId, IEnumerable<List<PointLatLng>> lists, GMapToolTip toolTip = null)
        {
            AMapOverlay routeOverLay = new GoogleMapRoute(gMapControl);
            GMapOverlay gMapOverlay = routeOverLay.SetOverLay(overLayId, lists, toolTip);
            return gMapOverlay;
        }
        public static GMapOverlay CreateMarker(this GMapControl gMapControl, string overLayId, double lat, double lng, GMapToolTip toolTip = null)
        {
            AMapOverlay markerOverLay = new GoogleMapMarker(gMapControl);
            GMapOverlay gMapOverlay = markerOverLay.SetOverLay(overLayId, lat, lng, toolTip);
            return gMapOverlay;
        }
        public static GMapOverlay CreateMarker(this GMapControl gMapControl, string overLayId, IEnumerable<PointLatLng> list, GMapToolTip toolTip = null)
        {
            AMapOverlay markerOverLay = new GoogleMapMarker(gMapControl);
            GMapOverlay gMapOverlay = markerOverLay.SetOverLay(overLayId, list, toolTip);
            return gMapOverlay;
        }
        public static void DeleteMarker(this GMapControl gMapControl, string overlayId)
        {
            AMapOverlay markerOverLay = new GoogleMapMarker(gMapControl);
            markerOverLay.DeleteOverLay(overlayId);
        }
        public static void ClearOverLay(this GMapControl gMapControl)
        {
            AMapOverlay markerOverLay = new GoogleMapMarker(gMapControl);
            markerOverLay.DeleteOverLay();
            gMapControl.Overlays.Clear();

        }
        public static void DeleteRoute(this GMapControl gMapControl, string overLayId)
        {
            AMapOverlay routeOverLay = new GoogleMapRoute(gMapControl);
           routeOverLay.DeleteRouteOverLay(overLayId);
        }

        
    }
}
