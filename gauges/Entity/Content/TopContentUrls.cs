using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Content
{
    using Newtonsoft.Json;

    public class TopContentUrls
    {
        [JsonProperty("older")]
        public string Older { get; set; }

        [JsonProperty("newer")]
        public string Newer { get; set; }

        [JsonProperty("previous_page")]
        public string PreviousPage { get; set; }

        [JsonProperty("next_page")]
        public string NextPage { get; set; }
    }
}
