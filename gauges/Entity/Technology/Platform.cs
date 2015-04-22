using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Technology
{
    using Newtonsoft.Json;

    public class Platform
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
