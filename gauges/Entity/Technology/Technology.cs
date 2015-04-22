using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Technology
{
    using Newtonsoft.Json;

    public class Technology
    {
        [JsonProperty("browsers")]
        public List<Browser> Browsers { get; set; }

        [JsonProperty("platforms")]
        public List<Platform> Platforms { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("urls")]
        public TechnologyUrls Urls { get; set; }
    }
}
