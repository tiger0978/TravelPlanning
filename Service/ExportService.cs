using Aspose.Words;
using AsposeWord;
using AutoMapper;
using GoogleMapAPI.Places;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;
using 旅遊景點規劃.Components;
using 旅遊景點規劃.Models;
using Image = System.Drawing.Image;

namespace 旅遊景點規劃
{
    public class ExportService
    {
        private ExportWord asposeWord = new ExportWord();
        public ExportService() { }

        public async void ExportFile(List<TravelPageInfo> travelPageInfos, TravelPlanInfo travelPlanInfo)
        {
            asposeWord.builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            asposeWord.builder.InsertImage(travelPlanInfo.imagePath);
            asposeWord.builder.InsertBreak(BreakType.ParagraphBreak);
            asposeWord.builder.Font.Size = 22;
            asposeWord.builder.Font.Bold = true;
            asposeWord.builder.Writeln(travelPlanInfo.title);
            asposeWord.builder.Font.Size = 18;
            asposeWord.builder.Writeln($"行程日期: {travelPlanInfo.StartDate.ToString("yyyy-MM-dd")}~{travelPlanInfo.EndDate.ToString("yyyy-MM-dd")}");
            asposeWord.builder.Writeln($"行程天數:{travelPlanInfo.travelDays.ToString()}");

            asposeWord.builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
            DateTime startDate = travelPlanInfo.StartDate;
            asposeWord.builder.InsertBreak(BreakType.PageBreak);
            for (int i =0; i < travelPageInfos.Count; i++) 
            {
                asposeWord.builder.Write($"第{i + 1}天 ({startDate.ToString("MMdd")})");
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<DailyTravelInfo, DailyTravelInfoDTO>()
                       .ForMember(x=> x.startTime, y=>y.MapFrom(z=>z.startTime.ToString("hh:mm")))
                       .ForMember(x => x.endTime, y => y.MapFrom(z => z.endTime.ToString("hh:mm")))
                       .ForMember(x => x.formatted_phone_number , y => y.MapFrom(z => z.placeDetail.result.formatted_phone_number))
                       .ForMember(x => x.name, y => y.MapFrom(z => z.placeDetail.result.name));
                });
                var mapper = config.CreateMapper();
                var result = mapper.Map<List<DailyTravelInfoDTO>>(travelPageInfos[i].placeDetails);
                asposeWord.BuildTable(result);

                asposeWord.builder.Writeln("路線規劃:");
                Image image = Image.FromFile(travelPageInfos[i].googlemapShot);
                asposeWord.builder.InsertImage(image);
                asposeWord.builder.InsertBreak(BreakType.ParagraphBreak);
            }
            asposeWord.builder.Write("地點資訊:\n");
            var datas = TravelScheduleService.travelPageInfos.SelectMany(x => x.placeDetails.Select(y => new PlaceInfoDTO
            {
                Name = y.placeDetail.result.name,
                Description = y.placeDetail.result.editorial_summary?.overview ?? "未提供",
                Address = y.placeDetail.result.formatted_address ?? "未提供",
                Phone = y.placeDetail.result.formatted_phone_number ?? "未提供" ,
                OpenTime = string.Join("\r\n", y.placeDetail.result.opening_hours?.weekday_text ?? new string[] {"未提供"}) ,
                Rating = y.placeDetail.result.rating.ToString() ?? "未提供",
                Photo_reference = y.placeDetail.result.photos[0]?.photo_reference ?? ""
            })).ToList();
            asposeWord.builder.Font.Size = 16;

            foreach (var data in datas)
            {
                asposeWord.builder.StartBookmark(data.Name);
                var props = data.GetType().GetProperties();
                foreach (var prop in props)
                {
                    string title = prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    if (prop.CustomAttributes.Any(x => x.AttributeType.Name.Contains("ImageTag")))
                    {
                        asposeWord.builder.Write($"{title}\n");
                        Image image = await PlaceService.GetPlacePhotoImage(prop.GetValue(data).ToString(), 232);
                        asposeWord.builder.InsertImage(image);
                        asposeWord.builder.InsertBreak(BreakType.ParagraphBreak);
                        continue;
                    }
                    string desc = prop.GetValue(data).ToString();
                    asposeWord.builder.Write($"{title}: {desc}\n");
                }
                asposeWord.builder.EndBookmark(data.Name);
            }
            string dircPath = Path.Combine(ConfigurationManager.AppSettings["rootPath"], $"{travelPlanInfo.title}_{travelPlanInfo.travelId}");
            if (!Directory.Exists(dircPath))
            {
                Directory.CreateDirectory(dircPath);
            }
            asposeWord.document.Save(Path.Combine(dircPath,$"旅遊計劃書_{travelPlanInfo.title}.docx"));
            asposeWord.document.Save(Path.Combine(dircPath, $"旅遊計劃書_{travelPlanInfo.title}.pdf"));

        }
    }
}
