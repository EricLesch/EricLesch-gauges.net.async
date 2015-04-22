using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Entity.Gauge;
    using Gauges.Service;

    [TestClass]
    public class TestGaugeLocationService
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var newGauge = await gaugeGaugeService.CreateGaugeAsync("GaugeTrafficServiceTest", "Eastern Time (US & Canada)");

            var gaugeLocationServie = new GaugeLocationService(TestConfig.GetApiKey());

            var locations = await gaugeLocationServie.GetLocationsAsync(newGauge.Id);

            Assert.IsNotNull(locations);

            // clean up
            await gaugeGaugeService.DeleteGaugeAsync(newGauge.Id);
        }
    }
}
