using System;
using Iasset.Service.DataModel;
using Iasset.Service.Extensions;
using NUnit.Framework;

namespace Iasset.UnitTests
{
    [TestFixture]
    public class WeatherServiceTest
    {
        private readonly WeatherModel _londonWeather = new FakeWeatherService()
            .GetWeather("United Kingdom", "London");

        public WeatherServiceTest()
        {
            Console.WriteLine(_londonWeather.ToJson());
        }

        [Test]
        public void When_London_Location_Is_Correct()
        {
            Assert.AreEqual("51.51,-0.13", _londonWeather.Location);
        }

        [Test]
        public void When_London_Visibility_Is_Correct()
        {
            Assert.AreEqual("10000m", _londonWeather.Visibility);
        }

        [Test]
        public void When_London_Sky_Is_Correct()
        {
            Assert.AreEqual("Clouds", _londonWeather.Sky);
        }

        [Test]
        public void When_London_Pressure_Is_Correct()
        {
            Assert.AreEqual("1020hPa", _londonWeather.Pressure);
        }

        [Test]
        public void When_London_Humidity_Is_Correct()
        {
            Assert.AreEqual("93%", _londonWeather.Humidity);
        }

        [Test]
        public void When_London_Temperature_Is_Correct()
        {
            Assert.AreEqual("3.48°C", _londonWeather.Temperature);
        }

        [Test]
        public void When_London_Wind_Is_Correct()
        {
            Assert.AreEqual("270° 3.6kph", _londonWeather.Wind);
        }
    }
}
