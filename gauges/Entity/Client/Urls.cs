using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Client
{
    using Newtonsoft.Json;

    public class Urls
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }
}
