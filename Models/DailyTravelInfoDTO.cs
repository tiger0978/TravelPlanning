using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 旅遊景點規劃.Attributes;

namespace 旅遊景點規劃.Models
{
    internal class DailyTravelInfoDTO
    {
        [DisplayName("抵達時間")]
        public string startTime { get; set; }
        [DisplayName("離開時間")]
        public string endTime { get; set; }
        [HyperLink]
        [DisplayName("地點名稱")]
        public string name { get; set; }
        [DisplayName("連絡電話")]
        public string formatted_phone_number { get; set; } = "未提供";
    }
}
