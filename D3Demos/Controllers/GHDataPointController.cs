using D3Demos.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace D3Demos.Controllers
{
    [RoutePrefix("api/gh")]
    public class GHDataPointController : ApiController
    {
        private readonly List<GHDataPoint> dataPoints;

        public GHDataPointController()
        {
            dataPoints = GetGHData();
        }

        [HttpGet]
        [Route("")]
        public List<GHDataPoint> GetAll(string tag)
        {

            return dataPoints;
        }

        [HttpGet]
        [Route("byCountry")]
        public List<GHDataPoint> GetByCountry(string country)
        {
            return dataPoints;
        }

        private List<GHDataPoint> GetGHData()
        {
            var path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, @"Data\GlobalHealth.json");
            var json = File.ReadAllText(path);
            var ghData = JsonConvert.DeserializeObject<List<GHDataPoint>>(json);
            return ghData;
        }
    }
}
