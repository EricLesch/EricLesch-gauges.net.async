using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Gauges.Entity.Share;
    using Gauges.Service;

    [TestClass]
    public class TestGaugeShareService
    {
        [TestMethod]
        public async Task TestGetGaugeShares()
        {
            var testEmail = "testgetgaugeshares@test.com";

            // create a gauge and the share it 
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var newGauge = await gaugeGaugeService.CreateGaugeAsync("TestGetGaugeShares", "Eastern Time (US & Canada)");

            var gaugeShareService = new GaugeShareService(TestConfig.GetApiKey());

            var newShare = await gaugeShareService.ShareGauge(newGauge.Id, testEmail);

            Assert.AreEqual(newShare.Email, testEmail);

            List<Share> shares = await gaugeShareService.GetSharesAsync(newGauge.Id);

            var foundAddedShare = shares.FirstOrDefault(x => x.Email == testEmail);

            Assert.IsNotNull(foundAddedShare);

            // cleanup
            await gaugeGaugeService.DeleteGaugeAsync(newGauge.Id);
        }
    }
}
