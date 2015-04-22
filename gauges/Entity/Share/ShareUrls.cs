using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Share
{
    using Newtonsoft.Json;

    public class ShareUrls
    {
        [JsonProperty("remove")]
        public string Remove { get; set; }
    }
}
