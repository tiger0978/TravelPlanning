using GoogleMapAPI.Common;
using GoogleMapAPI.Common.Enums;
using GoogleMapAPI.Places.FindPlace;
using GoogleMapAPI.Places.NearBySearch;
using GoogleMapAPI.Places.PlaceAutoComplete;
using GoogleMapAPI.Places.PlaceDetail;
using GoogleMapAPI.Places.PlacePhoto;
using GoogleMapAPI.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMapAPI.Places
{
    public class PlaceService : BaseService, IPlaceService
    {
        public BaseRequest Request;

        public PlaceService(BaseRequest request)
        {
            this.Request = request;
        }

        public static async Task<FindPlaceResponse> FindPlace(string searchText, FindPlaceInputType inputType)
        {
            BaseRequest request = new FindPlaceRequest(searchText, inputType);
            IPlaceService placeService = new PlaceService(request);
            var response = await placeService.GetResponse<FindPlaceResponse>();
            return response;
        }

        public static async Task<NearBySearchResponse> NearBySearch(string latlng, string radius, string searchType)
        {
            NearBySearchRequest nearBySearchRequest = new NearBySearchRequest(latlng, radius);
            nearBySearchRequest.type = searchType;
            IPlaceService placeService = new PlaceService(nearBySearchRequest);
            var response = await placeService.GetResponse<NearBySearchResponse>();
            return response;
        }

        public static async Task<PlaceAutoCompleteRespnse> PlaceAutoComplete(string input)
        {
            BaseRequest request = new PlaceAutoCompleteRequest(input);
            IPlaceService placeService = new PlaceService(request);
            var response = await placeService.GetResponse<PlaceAutoCompleteRespnse>();
            return response;
        }
        public static async Task<PlaceDetailResponse> PlaceDetail(string placeId)
        {
            BaseRequest request = new PlaceDetailRequest(placeId);
            IPlaceService placeService = new PlaceService(request);
            var response = await placeService.GetResponse<PlaceDetailResponse>();
            return response;
        }

        public async Task<T> GetResponse<T>()
        {
            var response = await httpRequest.GetAsync<T>(Request.URL);
            return response;
        }
        public static async Task<Image> GetPlacePhotoImage(string photo_reference, int maxheight)
        {
            BaseRequest request = new PlacePhotoRequest(photo_reference, maxheight);
            byte[] imageByte = await httpRequest.GetBytesAsync(request.URL);
            MemoryStream ms = new MemoryStream(imageByte);
            var image = Image.FromStream(ms);
            return image;
        }
    }
}
