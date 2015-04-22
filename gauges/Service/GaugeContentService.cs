using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.Content;

    public class GaugeContentService : GaugeService
    {
        public GaugeContentService(string apiKey): base(apiKey) { }

        public async Task<TopContent> GetTopContentAsync(string gaugeId, DateTime? date = null, int? page = null)
        {
            var url = String.Format("https://secure.gaug.es/gauges/{0}/content", gaugeId);

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

            TopContent topContent = Mapper<TopContent>.MapFromJson(json);

            return topContent;
        }
    }
}
