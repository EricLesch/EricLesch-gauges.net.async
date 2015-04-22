using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.Resolution;

    public class GaugeResolutionService : GaugeService
    {
        public GaugeResolutionService(string apiKey): base(apiKey) { }

        public async Task<AllResolutions> GetResolutionAsync(string gaugeId, DateTime? date = null) 
        {
            var url = String.Format("https://secure.gaug.es/gauges/{0}/resolutions", gaugeId);

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

            AllResolutions allResolutions = Mapper<AllResolutions>.MapFromJson(json);

            return allResolutions;
        }
    }
}
