using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gauges.Entity.Gauge;

    using Gauges.Service;

    [TestClass]
    public class TestGaugeGaugeService
    {
        [TestMethod]
        public async Task TestGetGaugeServices()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var createdGauge = await gaugeGaugeService.CreateGaugeAsync("TestCreatingAndDeletingGauges", "Eastern Time (US & Canada)");

            List<Gauge> gauges = await gaugeGaugeService.GetGaugesListAsync();

            var firstGauge = gauges.First();

            Assert.IsNotNull(firstGauge);

            // cleanup
            await gaugeGaugeService.DeleteGaugeAsync(createdGauge.Id);
        }

        [TestMethod]
        public async Task TestCreatingAndDeletingGauges()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var createdGauge = await gaugeGaugeService.CreateGaugeAsync("TestCreatingAndDeletingGauges", "Eastern Time (US & Canada)");

            Assert.IsNotNull(createdGauge);

            Gauge retrievedGauge = await gaugeGaugeService.GetGaugeAsync(createdGauge.Id);

            Assert.AreEqual(createdGauge.Id, retrievedGauge.Id);

            await gaugeGaugeService.DeleteGaugeAsync(createdGauge.Id);

            retrievedGauge = await gaugeGaugeService.GetGaugeAsync(createdGauge.Id);

            Assert.AreEqual(retrievedGauge, null);
        }

        [TestMethod]
        public async Task TestUpdatingGauges()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            const string ORIGINAL_TITLE = "TestUpdatingGauges";
            const string ORIGINAL_TIMEZONE = "Eastern Time (US & Canada)";

            var createdGauge = await gaugeGaugeService.CreateGaugeAsync(ORIGINAL_TITLE, ORIGINAL_TIMEZONE);

            Assert.AreEqual(createdGauge.Title, ORIGINAL_TITLE);

            const string MODIFIED_TITLE = "TestUpdatingGaugesModified";
            const string MODIFIED_TIMEZONE = "International Date Line West";

            var updatedGauge =
                await gaugeGaugeService.UpdateGaugeAsync(createdGauge.Id, MODIFIED_TITLE, MODIFIED_TIMEZONE);

            var retrievedGauge = await gaugeGaugeService.GetGaugeAsync(createdGauge.Id);

            Assert.AreEqual(retrievedGauge.Title, MODIFIED_TITLE);

            Assert.AreEqual(updatedGauge.Timezone, MODIFIED_TIMEZONE);

            // cleanup
            await gaugeGaugeService.DeleteGaugeAsync(updatedGauge.Id);
        }
    }
}
