using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Entity.Resolution
{
    using Newtonsoft.Json;

    public class AllResolutions
    {
        [JsonProperty("browser_widths")]
        public List<BrowserResolution> BrowserWidths { get; set; }

        [JsonProperty("browser_heights")]
        public List<BrowserResolution> BrowserHeights { get; set; }

        [JsonProperty("screen_widths")]
        public List<BrowserResolution> ScreenWidths { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("urls")]
        public ResolutionUrls Urls { get; set; }
    }
}
