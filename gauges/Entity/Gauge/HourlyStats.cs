﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Gauge
{
    using Newtonsoft.Json;

    public class HourlyStats
    {
        [JsonProperty("hour")]
        public string Hour { get; set; }

        [JsonProperty("views")]
        public int Views { get; set; }

        [JsonProperty("people")]
        public int People { get; set; }
    }
}
