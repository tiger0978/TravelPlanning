using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps.OverLays
{
    public class GoogleMapMarker : AMapOverlay
    {
        //GMapOverlay markers;

        public GoogleMapMarker(GMapControl gMapControl) : base(gMapControl)
        {
            this.gMapControl = gMapControl;
        }

        public override GMapOverlay SetOverLay(string overLayId, IEnumerable<List<PointLatLng>> lists, GMapToolTip toolTip = null)
        {
            throw new NotImplementedException("This Method is not Supported");
        }

        public override GMapOverlay SetOverLay(string overLayId, double lat, double lng, GMapToolTip toolTip = null)
        {
            GMapOverlay overlay = GetGMapOverLay(overLayId);
            GMapMarker marker = AddMarker(lat,lng, toolTip);
            overlay.Markers.Add(marker);
            return overlay;
        }

        public override GMapOverlay SetOverLay(string overLayId, IEnumerable<PointLatLng> list, GMapToolTip toolTip = null)
        {
            GMapOverlay overlay = GetGMapOverLay(overLayId);
            overlay.Clear();
            int markerIndex = 0;


            foreach (var pointLatLng in list)
            {
                GMapMarker marker = AddMarker(pointLatLng.Lat, pointLatLng.Lng,toolTip);
                overlay.Markers.Add(marker);
                marker.Tag = markerIndex++;
            }
            return overlay;
        }
        private GMapMarker AddMarker(double Lat, double Lng, GMapToolTip toolTip = null)
        {
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(Lat, Lng), GMarkerGoogleType.red_small);
            if (toolTip != null)
            {
                marker.ToolTip = toolTip;
            }
            return marker; 
        }
        private GMapOverlay GetGMapOverLay(string overLayId)
        {
            if (OverLays.ContainsKey(overLayId))
            {
                return OverLays[overLayId];
            }
            else
            {
                GMapOverlay markers = new GMapOverlay(overLayId);
                this.gMapControl.Overlays.Add(markers);
                OverLays.Add(overLayId, markers);
                return markers;
            }
        }
    }
}
