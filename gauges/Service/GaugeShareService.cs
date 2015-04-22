using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Linq.Expressions;
    using System.Net.Http;

    using Gauges.Entity.Share;

    public class GaugeShareService : GaugeService
    {
        public GaugeShareService(string apiKey): base(apiKey) { }

        private const string SHARES_URL = "https://secure.gaug.es/gauges/{0}/shares"; 

        /// <summary>
        /// Returns all of the shares for a given gauge
        /// </summary>
        /// <returns></returns>
        public async Task<List<Share>> GetSharesAsync(string gaugeId)
        {
            var url = GetSharesUrl(gaugeId);

            var json = await this.SendApiRequest(url, HttpMethod.Get);

            List<Share> clients = Mapper<Share>.MapCollectionFromJson(json, "shares");

            return clients;
        }

        /// <summary>
        /// Shares a gauge with a user with the given id
        /// </summary>
        /// <param name="gaugeId"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Share> ShareGauge(string gaugeId, string email)
        {
            var url = GetSharesUrl(gaugeId);

            var parameters = new Dictionary<string, string>();

            parameters.Add("email", email);

            var json = await this.SendApiRequest(url, HttpMethod.Post, parameters);

            Share share = Mapper<Share>.MapFromJson(json, "share");

            return share;
        }

        /// <summary>
        /// Unshares a gauge and returns the deleted share - 
        /// THIS METHOD IS TESTED BECAUSE I CANT DETERMINE A WAY TO GET 
        /// ANOTHER USER'S USER ID
        /// </summary>
        /// <param name="gaugeId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Share> UnShareGauge(string gaugeId, string userId)
        {
            var url = GetSharesUrl(gaugeId);

            var json = await this.SendApiRequest(url, HttpMethod.Delete, userId);

            Share share = Mapper<Share>.MapFromJson(json, "share");

            return share;
        }

        /// <summary>
        /// Return formatted url
        /// </summary>
        /// <param name="gaugeId"></param>
        /// <returns></returns>
        private string GetSharesUrl(string gaugeId)
        {
            return String.Format(SHARES_URL, gaugeId);
        }
    }
}
