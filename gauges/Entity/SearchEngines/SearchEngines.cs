using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.SearchEngines
{
    using Newtonsoft.Json;

    public class SearchEngines
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("engines")]
        public List<SearchEngine> Engines { get; set; }

        [JsonProperty("urls")]
        public SearchEngineUrls Urls { get; set; }
    }
}
