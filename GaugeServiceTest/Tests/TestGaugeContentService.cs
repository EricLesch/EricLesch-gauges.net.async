using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaugeServiceTest.Tests
{
    using Gauges.Service;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestGaugeContentService
    {
        [TestMethod]
        public async Task TestTopContentRetrieval()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var gaugeContentService = new GaugeContentService(TestConfig.GetApiKey());

            var gauge = await gaugeGaugeService.CreateGaugeAsync("TestTopContentRetrieval", "Eastern Time (US & Canada)");

            var topContent = await gaugeContentService.GetTopContentAsync(gauge.Id);

            Assert.IsNotNull(topContent);

            // delete the newly created gauge
            await gaugeGaugeService.DeleteGaugeAsync(gauge.Id);
        }
    }
}
