using GoogleMapAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Places.PlaceAutoComplete
{
    public class PlaceAutoCompleteRequest : BaseRequest
    {
        public string baseUrl = "place/autocomplete/json?";
        public string input { get; set; }
        public PlaceAutoCompleteRequest(string input)
        {
            this.input = input;
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
