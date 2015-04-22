using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Gauges
{
    public abstract class GaugeService
    {
        private string apiClientToken;

        public GaugeService(string apiClientToken)
        {
            this.apiClientToken = apiClientToken;
        }

        protected async Task<string> SendApiRequest(string url, HttpMethod httpMethod)
        {
            return await this.SendApiRequest(url, httpMethod, null, null);
        }

        protected async Task<string> SendApiRequest(
            string url,
            HttpMethod httpMethod,
            IDictionary<string, string> dataParameters)
        {
            return await this.SendApiRequest(url, httpMethod, null, dataParameters);
        }

        protected async Task<string> SendApiRequest(
            string url, 
            HttpMethod httpMethod, 
            string id,
            IDictionary<string, string> dataParameters = null)
        {
            // figure out if we need to add an id to the url
            if (id != null)
            {
                url += "/" + id;
            }

            var request = new HttpRequestMessage() {
                                               RequestUri = new Uri(url),
                                               Method = httpMethod
                                           };

            request.Headers.Add("X-Gauges-Token", apiClientToken);

            if (dataParameters != null)
            {
                request.Content = new FormUrlEncodedContent(dataParameters);
            }

            HttpResponseMessage response;
            string responseString;

            using (var client = new HttpClient())
            {
                response = await client.SendAsync(request);
                responseString = await response.Content.ReadAsStringAsync();
            }

            return responseString;
        }
    }
}
