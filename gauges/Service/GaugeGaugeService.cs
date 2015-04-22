using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges;
    using Gauges.Entity.Gauge;

    public class GaugeGaugeService : GaugeService
    {
        private const string GAUGE_URL = "https://secure.gaug.es/gauges";

        public GaugeGaugeService(string apiKey): base(apiKey) { }

        /// <summary>
        /// Retrieves a 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Gauge>> GetGaugesListAsync()
        {
            var json = await this.SendApiRequest(GAUGE_URL, HttpMethod.Get);

            List<Gauge> gauges = Mapper<Gauge>.MapCollectionFromJson(json, "gauges");

            return gauges;
        }

        /// <summary>
        /// Returns a gauge with the given id
        /// </summary>
        /// <returns></returns>
        public async Task<Gauge> GetGaugeAsync(string gaugeId)
        {
            var json = await this.SendApiRequest(GAUGE_URL, HttpMethod.Get, gaugeId);

            if (json.Contains("fail") && json.Contains("Not found"))
            {
                return null;
            }

            Gauge gauge = Mapper<Gauge>.MapFromJson(json, "gauge");

            return gauge;
        }

        /// <summary>
        /// Deletes a gauge with the given id 
        /// </summary>
        /// <param name="gaugeId"></param>
        /// <returns></returns>
        public async Task<Gauge> DeleteGaugeAsync(string gaugeId)
        {
            var json = await this.SendApiRequest(GAUGE_URL, HttpMethod.Delete, gaugeId);

            Gauge gauge = Mapper<Gauge>.MapFromJson(json, "gauge");

            return gauge;
        }

        /// <summary>
        /// Creates a new Gauge
        /// </summary>
        /// <param name="title"></param>
        /// <param name="timeZone"></param>
        /// <param name="allowedHosts"></param>
        /// <returns></returns>
        public async Task<Gauge> CreateGaugeAsync(string title, string timeZone, string allowedHosts = null)
        {
            var parameters = new Dictionary<string, string>();

            parameters.Add("title", title);
            parameters.Add("tz", timeZone);
            if (allowedHosts != null)
            {
                parameters.Add("allowed_hosts", allowedHosts);
            }

            var json = await this.SendApiRequest(GAUGE_URL, HttpMethod.Post, parameters);

            Gauge gauge = Mapper<Gauge>.MapFromJson(json, "gauge");

            return gauge;
        }

        public async Task<Gauge> UpdateGaugeAsync(string id, string title, string timeZone, string allowedHosts = null)
        {
            var parameters = new Dictionary<string, string>();

            parameters.Add("title", title);
            parameters.Add("tz", timeZone);
            if (allowedHosts != null)
            {
                parameters.Add("allowed_hosts", allowedHosts);
            }

            var json = await this.SendApiRequest(GAUGE_URL, HttpMethod.Put, id, parameters);

            Gauge gauge = Mapper<Gauge>.MapFromJson(json, "gauge");

            return gauge;
        }
    }
} 