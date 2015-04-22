using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.SearchTerms;

    public class GaugeSearchTermService : GaugeService
    {
        public GaugeSearchTermService(string apiKey): base(apiKey) { }

        public async Task<SearchTerms> GetSearchTermsAsync(string gaugeId, DateTime? date = null, int? page = null)
        {
            var url = String.Format("https://secure.gaug.es/gauges/{0}/terms", gaugeId);

            var parameters = new Dictionary<string, string>();
            if (date != null)
            {
                parameters.Add("date", date.ToString());
            }
            if (page != null)
            {
                parameters.Add("page", page.ToString());
            }

            if (!parameters.Any())
            {
                parameters = null;
            }

            var json = await this.SendApiRequest(url, HttpMethod.Get, parameters);

            SearchTerms searchTerms = Mapper<SearchTerms>.MapFromJson(json);

            return searchTerms;
        }
    }
}
