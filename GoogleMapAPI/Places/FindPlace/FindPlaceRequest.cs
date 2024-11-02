using GoogleMapAPI.Common.Enums;
using GoogleMapAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Places.FindPlace
{
    public class FindPlaceRequest : BaseRequest
    {
        public string baseUrl = "place/findplacefromtext/json?";
        public string input { get; set; }
        public string inputtype { get; set; }
        public string fields { get; set; } = "formatted_address%2Cname%2Crating%2Copening_hours%2Cgeometry";

        public FindPlaceRequest(string input, FindPlaceInputType inputType)
        {
            this.input = input;
            this.inputtype = inputType.ToString();
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
