﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點規劃
{
    public class AutoCompleteTextBoxData
    {
        public String Key { get; set; }
        public object Value { get; set; }
        public AutoCompleteTextBoxData(string key, Object value)
        {
            Key = key;
            Value = value;
        }
    }
}
