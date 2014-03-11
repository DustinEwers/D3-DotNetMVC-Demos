using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3Demos.Models
{
    public class TagDataPoint
    {
        public string TagName { get; set; }
        public int Rate { get; set; }
        public int MonthAsked { get; set; }
        public int YearAsked { get; set; }
    }
}