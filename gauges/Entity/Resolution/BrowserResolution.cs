using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Resolution
{
    using Newtonsoft.Json;

    public class BrowserResolution
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }
    }
}
