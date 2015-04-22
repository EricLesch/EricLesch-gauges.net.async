using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.SearchTerms
{
    using Newtonsoft.Json;

    public class SearchTerm
    {
        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }
    }
}
