using Newtonsoft.Json;

namespace Rainfall_Api
{
    public class Items
    {
        [JsonProperty("@id")]
        public string? Id { get; set; }
        public string? DateTime { get; set; }
        public string? Measure { get; set; }
        public double Value { get; set; }
    }
}
