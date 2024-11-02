using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps.OverLays
{
    public class GoogleMapRoute : AMapOverlay
    {
        Color[] colors = {Color.Blue,Color.Green,Color.Black,Color.Yellow,Color.Red };
        // AMapOverlay map = new GoogleMapRoute(gmapcontrol1);
        public GoogleMapRoute(GMapControl gMapControl) : base(gMapControl)
        {
            this.gMapControl = gMapControl;
        }

        public override GMapOverlay SetOverLay(string overLayId, IEnumerable<List<PointLatLng>> lists, GMapToolTip toolTip = null)
        {
            string keyword = overLayId.Split('_')[0];
            List<string> overlayKeys = OverLays.Keys.ToList();

            foreach (var key in overlayKeys)
            {
                if (key.Contains(keyword))
                {
                    if (OverLays.TryGetValue(key, out GMapOverlay overlay))
                    {
                        this.gMapControl.Overlays.Remove(overlay);
                        OverLays.Remove(key);
                    }
                }
            }
            GMapOverlay polygons = new GMapOverlay(overLayId);
            int index = 0;
            foreach (var list in lists)
            {
                GMapRoute polygon = new GMapRoute(list, overLayId+index.ToString());
                Random random = new Random();
                int colorIndex = random.Next(0, colors.Length);
                polygon.Stroke = new Pen(colors[colorIndex], 3);
                polygons.Routes.Add(polygon);
                this.gMapControl.Overlays.Add(polygons);
                OverLays.Add(overLayId + index.ToString(), polygons);
                index++;
            }
            return polygons;
        }

        public override GMapOverlay SetOverLay(string overLayId, double lat, double lng, GMapToolTip toolTip = null)
        {
            throw new NotImplementedException("This Method is not Supported");
        }
        public override GMapOverlay SetOverLay(string overLayId, IEnumerable<PointLatLng> points, GMapToolTip toolTip = null)
        {
            string keyword = overLayId.Split('_')[0];

            List<string> overlayKeys = OverLays.Keys.ToList();

            foreach (var key in overlayKeys) 
            {
                if (key.Contains(keyword))
                {
                    if (OverLays.TryGetValue(key, out GMapOverlay overlay))
                    {
                        this.gMapControl.Overlays.Remove(overlay);
                        OverLays.Remove(key);
                    }
                }
            }
            GMapOverlay polygons = new GMapOverlay(overLayId);
            GMapRoute polygon = new GMapRoute(points, overLayId);
            Random random = new Random();
            int colorIndex = random.Next(0,colors.Length);
            polygon.Stroke = new Pen(colors[colorIndex], 3);
            polygons.Routes.Add(polygon);
            this.gMapControl.Overlays.Add(polygons);
            OverLays.Add(overLayId, polygons);
            return polygons;
        }
    }
}
