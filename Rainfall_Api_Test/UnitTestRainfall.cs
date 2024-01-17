using Rainfall_Api;
using Rainfall_Api.Controllers;

namespace Rainfall_Api_Test
{
    public class Tests
    {
        private RainfallController controller;
        [SetUp]
        public void Setup()
        {
            controller = new RainfallController();
        }

        [TestCase("290200TP", 1)]
        [TestCase("290200TP", 100)]
        [TestCase("290200TP", 101)]
        public void Test1(string stationId, int count)
        {
            var result = controller.Readings(stationId, count);
            Assert.NotNull(result);
        }
    }
}