using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace 旅遊景點規劃
{
    internal class ComboxData
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public ComboxData(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
    
}
