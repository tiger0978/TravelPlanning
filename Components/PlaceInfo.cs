using GoogleMapAPI.Places.PlaceDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊景點規劃.Components
{
    public partial class PlaceInfo : UserControl
    {
        public PlaceInfo(PlaceDetailResponse placeDetail)
        {
            InitializeComponent();
            this.placeName.Text = placeDetail.result.name;
            this.rating_Num.Text = placeDetail.result.rating.ToString();
            this.Address.Text = placeDetail.result.formatted_address;
            this.phone.Text = placeDetail.result.international_phone_number;
            this.website.Text = placeDetail.result.website;
            this.commentNum.Text = $"({placeDetail.result.reviews?.Length.ToString()})" ?? "0";
        }

        private void PlaceInfo_Load(object sender, EventArgs e)
        {

        }
        private async void autoCompleteTextBox_SelectItem(object sender, Task<PlaceDetailResponse> e)
        {

        }
    }
}
