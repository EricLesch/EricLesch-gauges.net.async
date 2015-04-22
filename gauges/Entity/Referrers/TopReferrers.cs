using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Referrers
{
    using Newtonsoft.Json;

    public class TopReferrers
    {
        [JsonProperty("referrers")]
        public List<Referrer> Referrers { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("urls")]
        public TopReferrersUrl Urls { get; set; }
    }
}
