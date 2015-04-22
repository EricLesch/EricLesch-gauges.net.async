using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Content
{
    using System.Security.Policy;

    using Newtonsoft.Json;

    public class TopContent
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("content")]
        public List<Page> Content { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("urls")]
        public TopContentUrls Urls { get; set; }
    }
}
