using Newtonsoft.Json;

namespace Rainfall_Api
{
    public class Readings
    {
        [JsonProperty("@context")]
        public string? Context { get; set; }
        public Meta? Meta { get; set; }
        public List<Items>? Items { get; set; }
    }
}
