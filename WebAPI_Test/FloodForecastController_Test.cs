using Microsoft.Extensions.Logging;
using WebAPI;
using WebAPI.Controllers;

namespace WebAPI_Test
{
    public class Tests
    {
        private FloodForecastController _controller_test;

        [SetUp]
        public void Setup()
        {
            _controller_test = new FloodForecastController();
        }

        [Test]
        [TestCase("290200TP")]
        [TestCase("43200")]
        [TestCase("44200")]
        [TestCase("E7200")]
        [TestCase("200ABC")]
        public void FloodForecast_Test(string stationId)
        {
            //Assign
            //String stationId = "290200TP";

            //Act
            FloodForecast? result = _controller_test.Get(stationId);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}