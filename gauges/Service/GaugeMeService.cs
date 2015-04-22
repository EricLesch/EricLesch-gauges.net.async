using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.Me;

    public class GaugeMeService : GaugeService
    {
        public string ME_URL = "https://secure.gaug.es/me";
        public GaugeMeService(string apiKey): base(apiKey) { }

        public async Task<Me> GetMyInformationAsync()
        {
            var json = await this.SendApiRequest(ME_URL, HttpMethod.Get);

            Me me = Mapper<Me>.MapFromJson(json, "user");

            return me;
        }

        public async Task<Me> UpdateMyInformationAsync(string firstName, string lastName)
        {
            var parameters = new Dictionary<string, string>();

            if (firstName != null)
            {
                parameters.Add("first_name", firstName);               
            }
            if (lastName != null)
            {
                parameters.Add("last_name", lastName);
            }

            var json = await this.SendApiRequest(ME_URL, HttpMethod.Put, parameters);

            Me me = Mapper<Me>.MapFromJson(json, "user");

            return me;
        }
    }
}
