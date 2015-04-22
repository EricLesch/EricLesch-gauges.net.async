using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.SearchEngines;

    public class GaugeSearchEngineService : GaugeService
    {
        public GaugeSearchEngineService(string apiKey): base(apiKey) { }

        public async Task<SearchEngines> GetSearchEnginesAsync(string gaugeId, DateTime? date = null)
        {
            var url = String.Format("https://secure.gaug.es/gauges/{0}/engines", gaugeId);

            var parameters = new Dictionary<string, string>();

            if (date != null)
            {
               parameters.Add("date", date.ToString()); 
            }

            if (!parameters.Any())
            {
                parameters = null;
            }

            var json = await this.SendApiRequest(url, HttpMethod.Get, parameters);

            SearchEngines searchEngines = Mapper<SearchEngines>.MapFromJson(json);

            return searchEngines;
        }
    }
}
