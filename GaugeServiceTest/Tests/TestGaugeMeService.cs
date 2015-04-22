using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Service;

    [TestClass]
    public class TestGaugeMeService
    {
        [TestMethod]
        public async Task TestGetMe()
        {
            var gaugeMeService = new GaugeMeService(TestConfig.GetApiKey());

            var me = await gaugeMeService.GetMyInformationAsync();

            Assert.IsNotNull(me.FirstName);
            Assert.IsNotNull(me.LastName);
            Assert.IsNotNull(me.Name);
            Assert.IsNotNull(me.Email);
            Assert.IsNotNull(me.Id);
            Assert.IsNotNull(me.Urls.Gauges);
            Assert.IsNotNull(me.Urls.Self);
            Assert.IsNotNull(me.Urls.Clients);
        }

        [TestMethod]
        public async Task TestUpdateMe()
        {
            var gaugeMeService = new GaugeMeService(TestConfig.GetApiKey());

            const string NEW_FIRST_NAME = "Charles";
            const string NEW_LAST_NAME = "Xavier";

            var me = await gaugeMeService.UpdateMyInformationAsync(NEW_FIRST_NAME, NEW_LAST_NAME);

            me = await gaugeMeService.GetMyInformationAsync();

            Assert.AreEqual(me.FirstName, NEW_FIRST_NAME);
            Assert.AreEqual(me.LastName, NEW_LAST_NAME);

            Assert.IsNotNull(me.Name);
            Assert.IsNotNull(me.Email);
            Assert.IsNotNull(me.Id);
            Assert.IsNotNull(me.Urls.Gauges);
            Assert.IsNotNull(me.Urls.Self);
            Assert.IsNotNull(me.Urls.Clients);
        }
    }
}
