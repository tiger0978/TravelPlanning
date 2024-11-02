using GoogleMapAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapAPI.Geocoding
{
    public class GeocodingService : BaseService, IGeocodingService
    {
        GeocodingRequest geocodingRequest;
        public GeocodingService(GeocodingRequest geocodingRequest)
        {
            this.geocodingRequest = geocodingRequest;
        }
        public async Task<GeocodingResponse> GetGeoCodingResponse()
        {
            var response = await httpRequest.GetAsync<GeocodingResponse>(geocodingRequest.URL);
            return response;
        }
    }
}
