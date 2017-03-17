using System;
using Iasset.Service;
using Iasset.Service.DataModel;
using Iasset.Service.Extensions;
using Iasset.Service.WeatherProxy;
using Moq;
using NUnit.Framework;

namespace Iasset.UnitTests
{
    [TestFixture]
    public class WeatherServiceTest
    {
        private readonly WeatherModel _londonWeather;

        public WeatherServiceTest()
        {
            _londonWeather = CreateService().GetWeather("United Kingdom", "London");
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
            Assert.AreEqual("Clouds (broken clouds)", _londonWeather.Sky);
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

        [Test]
        public void When_London_Country_Is_Correct()
        {
            Assert.AreEqual("GB", _londonWeather.Country);
        }

        [Test]
        public void When_London_City_Is_Correct()
        {
            Assert.AreEqual("London", _londonWeather.City);
        }

        private static WeatherService CreateService()
        {
            var mock = new Mock<WeatherService>(new GlobalWeatherSoapClient("endpoint"), "api_key") { CallBase = true };

            mock.Setup(m => m.GetWeatherFromWeb(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new WeatherContainer
                {
                    Coord = new Coord {Lon = -0.13, Lat = 51.51},
                    Weather = new[] {new Weather {Main = "Clouds", Description = "broken clouds"}},
                    Main = new Main {Temp = 276.48, Pressure = 1020, Humidity = 93},
                    Visibility = 10000,
                    Wind = new Wind {Deg = 270, Speed = 3.6},
                    Dt = 1489731600,
                    Sys = new Sys {Country = "GB"},
                    Name = "London"
                });

            return mock.Object;
        }
    }
}
