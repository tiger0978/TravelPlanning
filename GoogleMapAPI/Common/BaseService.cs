using System;
using Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Common
{
    public class BaseService
    {
        public static HttpRequest httpRequest = new HttpRequest();
        static BaseService()
        {
            httpRequest.BaseUrl = "https://maps.googleapis.com/maps/api/";
        }
    }
}
