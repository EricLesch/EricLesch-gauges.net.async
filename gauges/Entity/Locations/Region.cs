using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Locations
{
    using Newtonsoft.Json;

    public class Region
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
