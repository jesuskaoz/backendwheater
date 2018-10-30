using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace code.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        
        // GET api/values/5
         [HttpGet("{lat}/{lon}/{temp}")]
        public async Task<ActionResult<HttpContent>> Wheater(double lat, double lon, string temp)
        {
            string Url="https://api.weatherbit.io/v2.0/forecast/daily?lat=" + lat + "&lon=" + lon + "&days=15&units=" + temp + "&lang=es&key=59c60d4cc2aa43bb860ef9ba1e27991c";
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Url.ToString());
            var stringResult = await response.Content.ReadAsStringAsync();
            return Content(stringResult.ToString(),"application/json");
        }
    }
}
