using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Referrers
{
    using Newtonsoft.Json;

    public class Referrer
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }
    }
}
