using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapAPI.Geocoding
{
    public interface IGeocodingService
    {
        Task<GeocodingResponse> GetGeoCodingResponse();
    }
}
