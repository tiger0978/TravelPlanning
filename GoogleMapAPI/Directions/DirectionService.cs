using GoogleMapAPI.Common;
using GoogleMapAPI.Common.Enums;
using GoogleMapAPI.Directions.Direction;
using GoogleMapAPI.Places;
using GoogleMapAPI.Places.NearBySearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapAPI.Directions
{
    public class DirectionService : BaseService, IDirectionService
    {
        public BaseRequest Request { get; set; }
        public DirectionService(BaseRequest request)
        {
            Request = request;
        }
        public async Task<T> GetResponse<T>()
        {
            var response = await httpRequest.GetAsync<T>(Request.URL);
            return response;
        }
        public static async Task<DirectionResponse> Direction (string origin, string destination, IEnumerable<Avoid> avoids, Mode mode,string wayPoints)
        {
            DirectionRequest directionRequest = new DirectionRequest(origin, destination, avoids, mode);
            directionRequest.waypoints = wayPoints;
            IPlaceService placeService = new PlaceService(directionRequest);
            var response = await placeService.GetResponse<DirectionResponse>();
            return response;
        }
    }
}
