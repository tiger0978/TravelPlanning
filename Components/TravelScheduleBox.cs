using GoogleMapAPI.Places;
using GoogleMapAPI.Places.PlaceAutoComplete;
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
using 旅遊景點規劃.Components.TubeUploader;
using 旅遊景點規劃.Events;
using 旅遊景點規劃.Models;

namespace 旅遊景點規劃.Components
{
    public partial class TravelScheduleBox : UserControl
    {

        public event EventHandler RemoveItem;
        public PlaceDetailResponse placeDetail;

        // new 一個 click 事件， usercontrol父類別中同名的事件會被優先觸發，但若 instance 直接建立子類別，會直接呼叫子類別的事件
        public new EventHandler Click {
            get
            {
                return null;
            }
            set //註冊 groupbox的事件及外傳進來的事件，已騙過編譯器
            {
                groupBox1.Click += value;
                groupBox1.Tag = this; // tag 放入自己，自己因為 call by reference 本體變動時會跟著變動
            } 
        }

        public TravelScheduleBox(string groupName, bool isDelete)
        {
            InitializeComponent();
            autoCompleteTextBox1.KeyUp += autoCompleteTextBox_TextChanged;
            autoCompleteTextBox1.SelectedItem += autoCompleteTextBox_SelectItem;

            this.groupBox1.Text = groupName;

            if (!isDelete) 
            {
                button1.Hide();
            }
        }
        public TravelScheduleBox()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RemoveItem?.Invoke(this,null);
        }
        private void autoCompleteTextBox_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteTextBox textBox = (AutoCompleteTextBox)sender;
            string input = textBox.Text;
            this.DebounceTime(async (state) =>
            {
                PlaceAutoCompleteRespnse response = await PlaceService.PlaceAutoComplete(state.ToString());
                List<AutoCompleteTextBoxData> autoCompleteTexts = response.predictions.Select(x => new AutoCompleteTextBoxData(x.structured_formatting.main_text, x)).ToList();
                textBox.Values = autoCompleteTexts;
            }, input, 500);
        }
        private async void autoCompleteTextBox_SelectItem(object sender, PlaceDetailResponse placeDetail)
        {
            this.placeDetail = placeDetail;
            DailyTravelInfo dailyTravelInfo = new DailyTravelInfo()
            {
                placeDetail = placeDetail,
                startTime = this.dateTimePicker1.Value,
                endTime = this.dateTimePicker2.Value,
            };
            PlaceEvent.SelectedPlaceNotify(this, dailyTravelInfo);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
