using System;

namespace Gauges.Entity.Client
{
    using Newtonsoft.Json;

    public class Client
    {
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("urls")]
        public Urls Urls { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
