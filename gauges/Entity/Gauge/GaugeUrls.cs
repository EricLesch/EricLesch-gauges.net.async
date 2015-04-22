using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Gauge
{
    using Newtonsoft.Json;

    public class GaugeUrls
    {
        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("referrers")]
        public string Referrers { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("traffic")]
        public string Traffic { get; set; }

        [JsonProperty("resolutions")]
        public string Resolutions { get; set; }

        [JsonProperty("technology")]
        public string Technology { get; set; }

        [JsonProperty("terms")]
        public string Terms { get; set; }

        [JsonProperty("engines")]
        public string Engines { get; set; }

        [JsonProperty("locations")]
        public string Locations { get; set; }

        [JsonProperty("shares")]
        public string Shares { get; set; }
    }
}
