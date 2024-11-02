using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 旅遊景點規劃.Attributes;

namespace 旅遊景點規劃.Models
{
    public class PlaceInfoDTO
    {
        [DisplayName("地點名稱")]
        public string Name { get; set; } 
        [DisplayName("介紹")]
        public string Description { get; set; } = "未提供";
        [DisplayName("評分")]
        public string Rating { get; set; } = "未提供";
        [DisplayName("地址")]
        public string Address { get; set; } = "未提供";
        [DisplayName("營業時間")]
        public string OpenTime { get; set; } = "未提供";
        [DisplayName("電話")]
        public string Phone { get; set; } = "未提供";
        [DisplayName("圖片")]
        [ImageTag]
        public string Photo_reference { get; set; } 
    }
}
