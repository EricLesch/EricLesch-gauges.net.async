using System;
using System.Collections.Generic;

namespace Gauges.Entity.Gauge
{
    using Newtonsoft.Json;
    public class Gauge
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("allowed_hosts")]
        public string AllowedHosts { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("tz")]
        public string Timezone { get; set; }

        [JsonProperty("now_in_zone")]
        public DateTime NowInZone { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("creator_id")]
        public string CreatorId { get; set; }

        [JsonProperty("urls")]
        public GaugeUrls Urls { get; set; }

        [JsonProperty("all_time")]
        public OverallStats AllTime { get; set; }

        [JsonProperty("today")]
        public DailyStats Today { get; set; }

        [JsonProperty("yesterday")]
        public DailyStats Yesterday { get; set; }
 
        [JsonProperty("recent_hours")]
        public List<HourlyStats> RecentHours { get; set; }

        [JsonProperty("recent_months")]
        public List<DailyStats> RecentMonths { get; set; }

        [JsonProperty("recent_days")]
        public List<DailyStats> RecentDays { get; set; }

        [JsonProperty("recent_years")]
        public List<DailyStats> RecentYears { get; set; }
    }
}
