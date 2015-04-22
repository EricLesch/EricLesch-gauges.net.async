using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Service;

    [TestClass]
    public class TestGaugeTechnologyService
    {
        [TestMethod]
        public async Task TestGetGaugeTechnology()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var gauge = await gaugeGaugeService.CreateGaugeAsync("TestGetGaugeTechnology", "Eastern Time (US & Canada)");

            var gaugeTechnologyService = new GaugeTechnologyService(TestConfig.GetApiKey());

            var technology = await gaugeTechnologyService.GetTechnologyAsync(gauge.Id);

            Assert.IsNotNull(technology);

            // cleanup
            await gaugeGaugeService.DeleteGaugeAsync(gauge.Id);
        }
    }
}
