using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Locations
{
    using Newtonsoft.Json;

    public class ViewLocations
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("locations")]
        public List<Location> Locations { get; set; }

        [JsonProperty("urls")]
        public LocationUrls Urls { get; set; }
    }
}
