using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Service;

    [TestClass]
    public class TestGaugeSearchEngineService
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var newGauge = await gaugeGaugeService.CreateGaugeAsync("GaugeTrafficServiceTest", "Eastern Time (US & Canada)");

            var gaugeSearchEngineService = new GaugeSearchEngineService(TestConfig.GetApiKey());

            var searchEngines = await gaugeSearchEngineService.GetSearchEnginesAsync(newGauge.Id);

            Assert.IsNotNull(searchEngines);

            // delete the newly created gauge
            await gaugeGaugeService.DeleteGaugeAsync(newGauge.Id);
        }
    }
}
