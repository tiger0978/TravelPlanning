using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 旅遊景點規劃.Attributes
{
    internal class BookMark: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }
        public BookMark(string name)
        {

        }
    }
}
