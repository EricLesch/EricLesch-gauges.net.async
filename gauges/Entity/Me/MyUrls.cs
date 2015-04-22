using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Me
{
    using Newtonsoft.Json;

    public class MyUrls
    {
        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("gauges")]
        public string Gauges { get; set; }

        [JsonProperty("clients")]
        public string Clients { get; set; }
    }
}
