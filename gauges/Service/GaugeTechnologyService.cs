using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.Technology;

    public class GaugeTechnologyService : GaugeService
    {
        public GaugeTechnologyService(string apiKey): base(apiKey) { }

        public async Task<Technology> GetTechnologyAsync(string gaugeId, DateTime? date = null)
        {
            var url = String.Format("https://secure.gaug.es/gauges/{0}/technology", gaugeId);

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

            Technology technology = Mapper<Technology>.MapFromJson(json);

            return technology;
        }
    }
}
