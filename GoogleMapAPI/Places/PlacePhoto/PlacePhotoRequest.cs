using GoogleMapAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Places.PlacePhoto
{
    public class PlacePhotoRequest : BaseRequest
    {
        public string baseUrl = "place/photo?";
        public string photo_reference { get; set; }
        public int maxheight { get; set; }
        public PlacePhotoRequest(string photo_reference, int maxheight)
        {
            this.photo_reference = photo_reference;
            this.maxheight = maxheight;
        }
        public override string URL
        {
            get
            {
                string url = baseUrl + base.ToUri();
                return url;
            }
        }
    }
}
