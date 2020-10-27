using APIServiceProposions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIServiceProposions.Controllers
{
    public class WeatherController : ApiController
    {
        // GET: api/Weather
        public IEnumerable<WeatherInfo> Get()
        {
            var weatherInfoList = new List<WeatherInfo>();
            for(int i=0; i<10; i++)
            {
                var wea = new WeatherInfo
                {
                    Location = $"Location {i}",
                    Temperature = i * 23 / 17,
                    DateTime = DateTime.Now.ToUniversalTime()
                };
                weatherInfoList.Add(wea);
            }
            return weatherInfoList;
        }

        // GET: api/Weather/5
        public WeatherInfo Get(int id)
        {
            return new WeatherInfo
            {
                Location = $"Location {id}",
                Temperature = id * 23 / 17,
                DateTime = DateTime.Now.ToUniversalTime()
            };
        }
    }
}
