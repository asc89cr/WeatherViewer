using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherViewerAPI.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherViewerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET: api/<WeatherController>
        [HttpGet]
        public async Task<string> Get()
        {
            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.weather.gov/gridpoints/TOP/33,36/forecast");

            //Add User-Agent. Looks like api requires a valid agent
            var productValue = new ProductInfoHeaderValue("PostmanRuntime", "7.28.4");
            request.Headers.UserAgent.Add(productValue);
            
            
            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                using (HttpContent content = response.Content)
                {
                    var json = content.ReadAsStringAsync().Result;
                    var objFromJson = JsonSerializer.Deserialize<Root>(json);

                    //get third period and send the response
                    return JsonSerializer.Serialize(objFromJson.properties.periods.Where(w => w.number.Equals(3)));
                }
            }
        }

        
    }
}
