using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Traffic
{
    using Newtonsoft.Json;

    public class DailyTraffic
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("people")]
        public int People { get; set; }
    }
}
