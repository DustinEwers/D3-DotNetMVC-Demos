using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D3Demos.Models
{
    public class DataSetResponse<T> where T : class 
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public int Length { get; set; }
        public List<T> Items { get; set; }        
    }
}