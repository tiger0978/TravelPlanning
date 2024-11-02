using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Utility
{
    public class LatLng
    {
        private double _latitude;
        private double _longitude;
        public LatLng()
        {
        }
        public LatLng(double latitude, double longitude)
        {
            this._latitude = Convert.ToDouble(latitude);
            this._longitude = Convert.ToDouble(longitude);
        }
        public double Latitude
        {
            get { return _latitude; }
        }
        public double Longitude
        {
            get { return _longitude; }
        }
    }
}
