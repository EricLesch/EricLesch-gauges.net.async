using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Traffic
{
    using Newtonsoft.Json;

    public class TrafficUrls
    {
        [JsonProperty("older")]
        public string Older { get; set; }

        [JsonProperty("newer")]
        public string Newer { get; set; }
    }
}
