using System.Configuration;
using Iasset.Service;
using Iasset.Service.DataModel;
using Iasset.Service.WeatherProxy;

namespace Iasset.UnitTests
{
    public class FakeLondonWeatherService : WeatherService
    {
        public FakeLondonWeatherService() : base(new GlobalWeatherSoapClient("GlobalWeatherSoap"),
            ConfigurationManager.AppSettings["openweathermap.api.key"]) {  }

        protected override WeatherContainer GetWeatherFromWeb(string country, string city)
        {
            return new WeatherContainer
            {
                Coord = new Coord {Lon = -0.13, Lat = 51.51},
                Weather = new[] {new Weather {Main = "Clouds", Description = "broken clouds"}},
                Main = new Main {Temp = 276.48, Pressure = 1020, Humidity = 93},
                Visibility = 10000,
                Wind = new Wind {Deg = 270, Speed = 3.6},
                Dt = 1489731600,
                Sys = new Sys {Country = "GB"},
                Name = "London"
            };
        }
    }
}
