using Newtonsoft.Json;

namespace WebAPI
{
    public class FloodForecast
    {
        [JsonProperty("@context")]
        public string? Context { get; set; }

        public Meta? Meta { get; set; }

        public Items? Items { get; set; }
    }

    public class Meta
    {
        public string? Publisher { get; set; }
        public string? Licence { get; set; }
        public string? Documentation { get; set; }
        public string? Version { get; set; }
        public string? Comment { get; set; }
        public List<string>? HasFormat { get; set; }
    }

    public class Items
    {
        [JsonProperty("@id")]
        public string? Id { get; set; }

        public string? EaRegionName { get; set; }
        public int Easting { get; set; }
        public string? GridReference { get; set; }
        public string? Label { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public Measures? Measures { get; set; }

        public int Northing { get; set; }
        public string? Notation { get; set; }
        public string? StationReference { get; set; }
        public string? Type { get; set; }
    }

    public class Measures
    {
        [JsonProperty("@id")]
        public string? Id { get; set; }
        public string? Label { get; set; }

        [JsonProperty("latestReading")]
        public LatestReading? LatestReading { get; set; }

        public string? Notation { get; set; }
        public string? Parameter { get; set; }
        public string? ParameterName { get; set; }
        public int Period { get; set; }
        public string? Qualifier { get; set; }
        public string? Station { get; set; }
        public string? StationReference { get; set; }
        public List<string>? Type { get; set; }
        public string? Unit { get; set; }
        public string? UnitName { get; set; }
        public string? ValueType { get; set; }
    }

    public class LatestReading
    {
        [JsonProperty("@id")]
        public string? Id { get; set; }
        public string? Date { get; set; }
        public string? DateTime { get; set; }
        public string? Measure { get; set; }
        public double Value { get; set; }
    }
}
