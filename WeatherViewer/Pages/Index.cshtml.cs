using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherViewer.Models;

namespace WeatherViewer.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }

        public List<TemperatureWindModel> GetForecast()
        {
            HttpClient client = new HttpClient();
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            var request = new HttpRequestMessage(HttpMethod.Get, Configuration.GetSection("WeatherAPI").Value);

            using (HttpResponseMessage response = client.SendAsync(request).Result)
            {
                using (HttpContent content = response.Content)
                {
                    var json = content.ReadAsStringAsync().Result;
                    var result = JsonSerializer.Deserialize<List<TemperatureWindModel>>(json);
                    return result;
                }
            }
        }
    }
}
