using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.Traffic;

    public class GaugeTrafficService : GaugeService
    {
        public GaugeTrafficService(string apiKey): base(apiKey) { }

        public async Task<GaugeTraffic> GetGaugeTrafficAsync(string gaugeId, DateTime? date = null)
        {
            var url = String.Format("https://secure.gaug.es/gauges/{0}/traffic", gaugeId);

            var parameters = new Dictionary<string, string>();

            if (date != null)
            {
                 parameters.Add("date", date.ToString());               
            }

            if (parameters.Count == 0)
            {
                parameters = null;
            }

            var json = await this.SendApiRequest(url, HttpMethod.Get, parameters);

            GaugeTraffic gaugeTraffic = Mapper<GaugeTraffic>.MapFromJson(json);

            return gaugeTraffic;
        }
    }
}
