using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Entity.Gauge;
    using Gauges.Service;

    [TestClass]
    public class TestGaugeSearchTermService
    {
        [TestMethod]
        public async Task TestGetSearchTerms()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            Gauge newGauge = await gaugeGaugeService.CreateGaugeAsync("TestGetSearchTerms", "Eastern Time (US & Canada)");

            var gaugeSearchTermService = new GaugeSearchTermService(TestConfig.GetApiKey());

            var searchTerms = await gaugeSearchTermService.GetSearchTermsAsync(newGauge.Id);

            Assert.IsNotNull(searchTerms);

            // cleanup
            await gaugeGaugeService.DeleteGaugeAsync(newGauge.Id);
        }
    }
}
