using Aspose.Words;
using Aspose.Words.Drawing;
using Aspose.Words.Reporting;
using Aspose.Words.Tables;
using DocumentFormat.OpenXml.Spreadsheet;
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
using Xceed.Words.NET;
using Color = System.Drawing.Color;
using License = Aspose.Words.License;
using Table = Aspose.Words.Tables.Table;
using Underline = Aspose.Words.Underline;

namespace AsposeWord
{
    public class ExportWord
    {
        private License license = new License();
        public Document document;
        public DocumentBuilder builder;

        public ExportWord(string licenseFile,string filePath)
        {
            license.SetLicense(licenseFile);
            document = new Document(filePath);
            builder = new DocumentBuilder(document);
            builder.Font.Name = "微軟正黑體";
            builder.Font.Size = 18;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        }

        public ExportWord() 
        {
            string licenseFile = ConfigurationManager.AppSettings["licenseFile"];

            if (String.IsNullOrEmpty(licenseFile))
            {
                throw new Exception("Config 未放 License File 路徑");
            }
            license.SetLicense(licenseFile);
            document = new Document();
            builder = new DocumentBuilder(document);
            builder.Font.Name = "微軟正黑體";
            builder.Font.Size = 18;
            builder.ParagraphFormat.Alignment = ParagraphAlignment.Left;
        }
        
        public void BuildTable<T>(List<T> list)
        {
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();
            builder.Font.Name = "微軟正黑體";
            builder.Font.Size = 14;
            foreach (PropertyInfo prop in props)  //建立 header
            {
                builder.InsertCell();
                string title = prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                builder.Write(title);
            }
            builder.EndRow();
            builder.Font.Size = 12;
            foreach (var item in list) 
            {
                props = item.GetType().GetProperties();
                foreach (PropertyInfo prop in props) 
                {
                    var chechHyperLink = prop.CustomAttributes.Where(x => x.AttributeType.Name.Contains("HyperLink")).FirstOrDefault();
                    if(chechHyperLink != null)
                    {
                        builder.Font.Color = Color.Blue;
                        builder.Font.Underline = Underline.Single;
                        string hyperlinkName = prop.GetValue(item).ToString();
                        builder.InsertCell();
                        builder.InsertHyperlink(hyperlinkName, hyperlinkName, true);
                        builder.Font.ClearFormatting();
                        builder.Font.Name = "微軟正黑體";
                    }
                    else
                    {
                        builder.InsertCell();
                        builder.Write(prop.GetValue(item)?.ToString() ?? "未提供");
                    }
                }
                builder.EndRow();
            }
        }
        public void CreateBookMark(string bookmarkName, Action<DocumentBuilder> func)  
        {
            builder.StartBookmark(bookmarkName);
            func.Invoke(builder);
            builder.EndBookmark(bookmarkName);
        }
    }
}
