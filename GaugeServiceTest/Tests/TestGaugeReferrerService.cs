using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Service;

    [TestClass]
    public class TestGaugeReferrerService
    {
        [TestMethod]
        public async Task TestGaugeReffererService()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var gaugeReferrerService = new GaugeReferrerService(TestConfig.GetApiKey());

            var gauge = await gaugeGaugeService.CreateGaugeAsync("TestGaugeReffererService", "Eastern Time (US & Canada)");

            var topReferrers = await gaugeReferrerService.GetTopReferrersAsync(gauge.Id);

            Assert.IsNotNull(topReferrers);

            // cleanup
            await gaugeGaugeService.DeleteGaugeAsync(gauge.Id);
        }
    }
}
