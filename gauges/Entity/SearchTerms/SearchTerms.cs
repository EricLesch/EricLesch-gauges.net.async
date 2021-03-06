﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.SearchTerms
{
    using Newtonsoft.Json;

    public class SearchTerms
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        [JsonProperty("terms")]
        public List<SearchTerm> Terms { get; set; }

        [JsonProperty("urls")]
        public SearchTermUrls Urls { get; set; }
    }
}
