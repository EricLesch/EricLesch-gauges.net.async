using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Service;

    [TestClass]
    public class TestGaugeTrafficService
    {
        [TestMethod]
        public async Task GaugeTrafficServiceTest()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var newGauge = await gaugeGaugeService.CreateGaugeAsync("GaugeTrafficServiceTest", "Eastern Time (US & Canada)");

            var gaugeTrafficService = new GaugeTrafficService(TestConfig.GetApiKey());

            var gaugeTraffic = await gaugeTrafficService.GetGaugeTrafficAsync(newGauge.Id);

            Assert.IsNotNull(gaugeTraffic);

            // clean up
            await gaugeGaugeService.DeleteGaugeAsync(newGauge.Id);
        }
    }
}
