using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Rainfall_Api.Controllers
{
    [Route("rainfall/id")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private static string API_ROOT = "http://environment.data.gov.uk";
        private string apiReading = "/flood-monitoring/id/stations/{0}/readings?_limit={1}";

        [HttpGet("{stationId}/readings", Name = "readings")]
        public ActionResult<Readings>? Readings(string stationId, int count = 10) 
        {
            if (count < 1 || count > 100)
            {
                return BadRequest("Invalid request");
            }

            var result = new Readings();
            using (var http = new HttpClient())
            {
                http.BaseAddress = new Uri(API_ROOT);
                HttpResponseMessage response = http.GetAsync(string.Format(apiReading, stationId, count)).Result;

                if (response.IsSuccessStatusCode)
                {
                    string context = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<Readings>(context);
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound("No readings found for the specified stationId: {stationId}");
                }
                else
                {
                    return StatusCode((int)response.StatusCode, "Internal server error.");
                }
            }
            return Ok(result);
        }
    }
}
