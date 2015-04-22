using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Entity.Resolution;
    using Gauges.Service;

    [TestClass]
    public class TestGaugeResolutionService
    {
        [TestMethod]
        public async Task TestResolutionService()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var newGauge =
                await gaugeGaugeService.CreateGaugeAsync("TestResolutionService", "Eastern Time (US & Canada)");

            var gaugeResolutionService = new GaugeResolutionService(TestConfig.GetApiKey());

            AllResolutions resolutions = await gaugeResolutionService.GetResolutionAsync(newGauge.Id);

            Assert.IsNotNull(resolutions);

            // cleanup
            await gaugeGaugeService.DeleteGaugeAsync(newGauge.Id);
        }
    }
}
