using GMap.NET;
using GMap.NET.WindowsForms;
using GoogleMapAPI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps.OverLays
{
    public abstract class AMapOverlay
    {
        protected GMapControl gMapControl;
        protected static Dictionary<string, GMapOverlay> OverLays = new Dictionary<string, GMapOverlay>();

        public AMapOverlay(GMapControl gMapControl)
        {
            this.gMapControl = gMapControl;
        }
        public void DeleteRouteOverLay(string overLayId)
        {
            string keyword = overLayId.Split('_')[0];

            List<string> keys = OverLays.Keys.Where(x => x.Contains(keyword)).ToList();
            foreach (string key in keys)
            {
                if (OverLays.TryGetValue(key, out GMapOverlay overlay))
                {
                    this.gMapControl.Overlays.Remove(overlay);
                    OverLays.Remove(key);
                }
            }
        }

        public void DeleteOverLay(string overLayId)
        {
            if (OverLays.ContainsKey(overLayId)){
                this.gMapControl.Overlays.Remove(OverLays[overLayId]);
                OverLays.Remove(overLayId);
            }
        }

        public void DeleteOverLay()
        {
            OverLays.Clear();
        }



        public abstract GMapOverlay SetOverLay(string overLayId, IEnumerable<List<PointLatLng>> lists, GMapToolTip toolTip = null);
        public abstract GMapOverlay SetOverLay(string overLayId, double lat, double lng, GMapToolTip toolTip = null);
        public abstract GMapOverlay SetOverLay(string overLayId, IEnumerable<PointLatLng> list, GMapToolTip toolTip = null);

    }
}
