using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Locations
{
    using Newtonsoft.Json;

    public class LocationUrls
    {
        [JsonProperty("older")]
        public string Older { get; set; }

        [JsonProperty("newer")]
        public string Newer { get; set; }
    }
}
