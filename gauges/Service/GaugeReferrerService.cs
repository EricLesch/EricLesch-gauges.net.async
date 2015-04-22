using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;
    using System.Runtime.InteropServices;

    using Gauges.Entity.Referrers;

    public class GaugeReferrerService : GaugeService
    {
        public GaugeReferrerService(string apiKey): base(apiKey) { }

        public async Task<TopReferrers> GetTopReferrersAsync(string gaugeId, DateTime? date = null, int? page = null)
        {
            var url = String.Format("https://secure.gaug.es/gauges/:id/referrers", gaugeId);

            var parameters = new Dictionary<string, string>();
            if (date != null)
            {
                 parameters.Add("date", date.ToString());               
            }
            if (page != null)
            {
                parameters.Add("page", page.ToString());
            }

            if (parameters.Count == 0)
            {
                parameters = null;
            }

            var json = await this.SendApiRequest(url, HttpMethod.Get, parameters);

            TopReferrers topReferrers = Mapper<TopReferrers>.MapFromJson(json);

            return topReferrers;
        }
    }
}
