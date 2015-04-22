using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaugeServiceTest.Tests
{
    using System.Threading.Tasks;

    using Gauges.Service;

    [TestClass]
    public class DeleteAllGauges
    {
        [TestMethod]
        public async Task DeleteAllTheThings()
        {
            var gaugeGaugeService = new GaugeGaugeService(TestConfig.GetApiKey());

            var gauges = await gaugeGaugeService.GetGaugesListAsync();

            foreach (var gauge in gauges)
            {
                await gaugeGaugeService.DeleteGaugeAsync(gauge.Id);
            }
        }
    }
}
