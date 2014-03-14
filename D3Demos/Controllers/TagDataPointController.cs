using D3Demos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace D3Demos.Controllers
{
    [RoutePrefix("api/tags")]
    public class TagDataPointController : ApiController
    {
        private readonly List<TagDataPoint> dataPoints;

        public TagDataPointController() {
            dataPoints = GetSOData();
        }

        [HttpGet]
        [Route("")]
        public List<TagDataPoint> GetAll()
        {
            return dataPoints.OrderBy(m => String.Format("{0}-{1}-{2}", m.TagName, m.YearAsked, m.MonthAsked.ToString("00"))).ToList();
        }

        [HttpGet]
        [Route("{tag}")]
        public DataSetResponse<TagDataPoint> GetByTag(string tag)
        {
            var items = dataPoints.Where(m=>m.TagName == tag)
                                  .OrderBy(m => String.Format("{0}-{1}", m.YearAsked, m.MonthAsked.ToString("00")))
                                  .ToList();
            var response = new DataSetResponse<TagDataPoint>()
            {
                Min = items.Min(t => t.Rate), // we could do this in javaScript with d3.min
                Max = items.Max(t => t.Rate), // we could do this in javaScript with d3.max
                Length = items.Count(),
                Items = items
            };

            return response;
        }

        private List<TagDataPoint> GetSOData() {
            var path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"Data\StackOverflow.json");
            var json = File.ReadAllText(path);
            var soData = JsonConvert.DeserializeObject<List<TagDataPoint>>(json);
            return soData;
        }
    }
}
