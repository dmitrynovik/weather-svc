using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Iasset.Service;
using Iasset.Service.Extensions;
using Iasset.Service.WeatherProxy;
using NUnit.Framework;

namespace Iasset.UnitTests
{
    [TestFixture]
    public class WeatherServiceTest
    {
        [Test]
        public async Task When_Country_UK_All_Cities_Returned()
        {
            var cities = await CreateService().GetCitiesByCountry("United Kingdom");
            cities.ToList().ForEach(Console.WriteLine);
            Assert.Contains("London Weather Centre", cities.ToList());
        }

        [Test]
        public void GetWeather()
        {
            var weather = CreateService().GetWeather("United Kingdom", "London");
            Console.WriteLine(weather.ToJson());
        }

        private WeatherService CreateService()
        {
            var apiKey = ConfigurationManager.AppSettings["openweathermap.api.key"];
            return new WeatherService(new GlobalWeatherSoapClient("GlobalWeatherSoap"), apiKey);
        }
    }
}
