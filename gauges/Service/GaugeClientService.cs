using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gauges.Service
{
    using System.Net.Http;

    using Gauges.Entity.Client;

    public class GaugeClientService : GaugeService
    {
        public GaugeClientService(string apiKey): base(apiKey) { }

        private const string CLIENT_URL = "https://secure.gaug.es/clients";

        /// <summary>
        /// Returns a list of all the clients in the Gauges account
        /// </summary>
        /// <returns></returns>
        public async Task<List<Client>> GetClientsAsync()
        {
            var json = await this.SendApiRequest(CLIENT_URL, HttpMethod.Get);

            List<Client> clients = Mapper<Client>.MapCollectionFromJson(json, "clients");

            return clients;
        }

        /// <summary>
        /// Creates a new Client with the passed description
        /// </summary>
        /// <returns></returns>
        public async Task<Client> CreateClientAsync(string description)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("description", description);

            var json = await this.SendApiRequest(CLIENT_URL, HttpMethod.Post, parameters);

            Client client = Mapper<Client>.MapFromJson(json, "client");

            return client;
        }

        /// <summary>
        /// Deletes a client with the given clientId - clientId corresponds to the "key" property on a client
        /// </summary>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public async Task<Client> DeleteClientAsync(string clientId)
        {
            var json = await this.SendApiRequest(CLIENT_URL, HttpMethod.Delete, clientId);

            Client client = Mapper<Client>.MapFromJson(json, "client");

            return client;
        }
    }
}
