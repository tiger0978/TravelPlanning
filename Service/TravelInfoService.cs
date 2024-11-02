using CSV;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 旅遊景點規劃.Models;

namespace 旅遊景點規劃
{
    public class TravelInfoService
    {
        private string filePath {  get; set; }
        private string rootPath { get; set; }
        private CSVHelper csvHelper;


        public TravelInfoService(string rootPath, string filePath) 
        {
            this.rootPath = rootPath;
            this.filePath = filePath;
            csvHelper = new CSVHelper(rootPath);
        }

        public void SaveJSONFile(TabControl tabControl,TravelPlanInfo planInfo) //ToDo: 之後須與 travelscheduleService 整合
        {
            string json_travelInfo = JsonConvert.SerializeObject(TravelScheduleService.travelPageInfos);
            string dircPath = Path.Combine(rootPath,$"{planInfo.title}_{planInfo.travelId}");
            if (!Directory.Exists(dircPath))
            {
                Directory.CreateDirectory(dircPath);
            }
            string path = Path.Combine(dircPath, $"{planInfo.title}.json");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.WriteAllText(path, json_travelInfo);
        }

        public List<TravelPageInfo> ReadFile()
        {
            string path = Path.Combine(rootPath, filePath);
            List<TravelPageInfo> travelPageInfos = new List<TravelPageInfo>();
            if (!File.Exists(path))
            {
                return travelPageInfos;
            }
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                travelPageInfos = JsonConvert.DeserializeObject<List<TravelPageInfo>>(json);
            }
            return travelPageInfos;
        }
        public void SaveAllInfoCSV(TravelPlanInfo travelPlanInfo)
        {
            if (travelPlanInfo.imagePath != null)
            {
                string dircPath = Path.Combine(rootPath, $"{travelPlanInfo.title}_{travelPlanInfo.travelId}");
                if (!Directory.Exists(dircPath))
                {
                    Directory.CreateDirectory(dircPath);
                }
                string imagePath = Path.Combine(dircPath,$"{travelPlanInfo.title}.jpg");
                using (Image image = new Bitmap(travelPlanInfo.imagePath)) 
                {
                    image.Save(imagePath);
                    travelPlanInfo.imagePath = imagePath;
                }
                GC.Collect();
            }
            csvHelper.WriteToCSV(filePath, travelPlanInfo);
        }

        public List<TravelPlanInfo> ReadTravelInfos()
        {
            List<TravelPlanInfo> travelPlanInfos = csvHelper.ReadCSV<TravelPlanInfo>(filePath);
            return travelPlanInfos;
        }

        public bool CheckDataExisted(TravelPlanInfo travelPlanInfo)
        {
            List<TravelPlanInfo> travelPlanInfos = csvHelper.ReadCSV<TravelPlanInfo>(filePath);
            bool isExisted = travelPlanInfos.Any(x => x.travelId == travelPlanInfo.travelId);
            return isExisted;
        }
    }
}
