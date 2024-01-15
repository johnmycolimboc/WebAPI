using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FloodForecastController : Controller
    {
        private static string API_ROOT = "http://environment.data.gov.uk";
        private string[] api = { 
            "/flood-monitoring/id/stations/{0}",
            "/flood-monitoring/id/stations/{0}/measures",
            "/flood-monitoring/id/stations/{0}/readings",
            "/flood-monitoring/id/stations/{0}/readings?today&_sorted&parameter=rainfall"};

        private readonly ILogger<FloodForecastController> _logger;

        public FloodForecastController(ILogger<FloodForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetFloodForecast")]
        public FloodForecast? Get(string stations)
        {
            FloodForecast? floodForecast = default;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_ROOT);

                HttpResponseMessage responseMessage = client.GetAsync(string.Format(api[0], stations)).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = responseMessage.Content.ReadAsStringAsync().Result;
                    floodForecast = JsonConvert.DeserializeObject<FloodForecast>(content);
                }
                return floodForecast;
            }
        }

    }
}
