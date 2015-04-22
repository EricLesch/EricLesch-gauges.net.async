using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gauges.Entity.Client;

    using Gauges.Service;

    [TestClass]
    public class TestGaugeClientService 
    {
        [TestMethod]
        public async Task TestGetClientAsync()
        {
            var gaugeClientService = new GaugeClientService(TestConfig.GetApiKey());

            List<Client> clients = await gaugeClientService.GetClientsAsync();
            Client firstClient = clients.First();

            Assert.IsNotNull(firstClient.Description);
            Assert.IsNotNull(firstClient.CreatedAt);
            Assert.IsNotNull(firstClient.Key);

            Assert.IsNotNull(firstClient.Urls);
            Assert.IsNotNull(firstClient.Urls.Self);
        }

        [TestMethod]
        public async Task TestCreateAndDeleteClientAsync()
        {
            var gaugeClientService = new GaugeClientService(TestConfig.GetApiKey());

            // create a client
            Client client = await gaugeClientService.CreateClientAsync("Test Description");

            Assert.IsNotNull(client.Description);
            Assert.IsNotNull(client.CreatedAt);
            Assert.IsNotNull(client.Key);

            Assert.IsNotNull(client.Urls);
            Assert.IsNotNull(client.Urls.Self);

            // should exist when queried
            var clients = await gaugeClientService.GetClientsAsync();

            Client shouldNotBeNull = clients.FirstOrDefault(x => x.Key == client.Key);

            Assert.IsNotNull(shouldNotBeNull);

            // delete the client
            var deletedClient = await gaugeClientService.DeleteClientAsync(client.Key);

            Assert.AreEqual(client.Description, deletedClient.Description);
            Assert.AreEqual(client.CreatedAt, deletedClient.CreatedAt);
            Assert.AreEqual(client.Key, deletedClient.Key);

            Assert.AreEqual(client.Urls.Self, deletedClient.Urls.Self);

            // should not exist when queried
            clients = await gaugeClientService.GetClientsAsync();

            Client shouldBeNull = clients.FirstOrDefault(x => x.Key == deletedClient.Key);

            Assert.IsNull(shouldBeNull);
        }
    }
}
