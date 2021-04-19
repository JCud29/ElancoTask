using Newtonsoft.Json;

namespace Elanco_Task
{
    public record App
    {
        [JsonProperty]
        public string ConsumedQuantity { get; set; }
        [JsonProperty]
        public string Cost { get; set; }
        [JsonProperty]
        public string Date { get; set; }
        [JsonProperty]
        public string InstanceId { get; set; }
        [JsonProperty]
        public string MeterCategory { get; set; }
        [JsonProperty]
        public string ResourceGroup { get; set; }
        [JsonProperty]
        public string ResourceLocation { get; set; }
        [JsonProperty]
        public Tags Tags { get; set; }
        [JsonProperty]
        public string UnitOfMeasure { get; set; }
        [JsonProperty]
        public string Location { get; set; }
        [JsonProperty]
        public string ServiceName { get; set; }
    }

    public record Tags
    {
        [JsonProperty("app-name")]
        public string AppName { get; set; }
        [JsonProperty("environment")]
        public string Environment { get; set; }
        [JsonProperty("business-unit")]
        public string BusinessUnit { get; set; }
    }
}
