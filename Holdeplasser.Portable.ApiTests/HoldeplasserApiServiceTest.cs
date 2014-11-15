using System;
using System.Linq;
using System.Threading.Tasks;
using Holdeplasser.Portable.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Holdeplasser.Portable.ApiTests
{
    [TestClass]
    public class HoldeplasserApiServiceTest
    {
        [TestMethod]
        public async Task Test_GetStopsByArea()
        {
            var result =
                await
                    HoldeplasserApiService.GetStopsByAreaAsync(59.91928939238661, 10.748065725097603, 59.91371783347825,
                        10.686954274902291);

            var containsStops = result.Any();

            Assert.IsNotNull(result);
            Assert.IsTrue(containsStops);
        }

        [TestMethod]
        public async Task Test_GetTipsForStop()
        {
            var stopId = 3010020; // Stortinget T-bane

            var result = await HoldeplasserApiService.GetTipsForStopId(stopId);

            var totalTipsHaveCount = result.TotalTips > 0;
            var totalTipsInList = result.Tips.Count() == result.TotalTips;

            Assert.IsNotNull(result);
            Assert.IsTrue(totalTipsHaveCount, "Total tips are zero. This is a real API test, so check your data");
            Assert.IsTrue(totalTipsInList, "Tips in the collection does not match the total tips given. Check your parser");
        }

        [TestMethod]
        public async Task Test_SearchTipsWithDefaultValues()
        {
            var result = await HoldeplasserApiService.SearchTipsAsync();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TotalTips > 0);
            Assert.IsTrue(result.Tips.Any());
        }

        [TestMethod]
        public async Task Test_SearchTipsWithQuery()
        {
            var result = await HoldeplasserApiService.SearchTipsAsync(searchQuery: "ita");

            Assert.IsNotNull(result);
            Assert.IsTrue(result.TotalTips > 0);
            Assert.IsTrue(result.Tips.Any());
        }
    }
}
