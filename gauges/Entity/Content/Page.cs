using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Content
{
    using Newtonsoft.Json;

    public class Page
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
