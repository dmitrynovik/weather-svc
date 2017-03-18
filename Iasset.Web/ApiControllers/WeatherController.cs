using System;
using System.Web.Http;
using Iasset.Service;

namespace Iasset.Web.ApiControllers
{
    public class WeatherController : ApiController
    {
        private readonly WeatherService _weatherService;

        public WeatherController(WeatherService weatherService)
        {
            if (weatherService == null) throw new ArgumentNullException(nameof(weatherService));
            _weatherService = weatherService;
        }

        public IHttpActionResult GetCities(string country)
        {
            var cities = _weatherService.GetCitiesByCountry(country);
            return Ok(cities);
        }

        public IHttpActionResult GetWeather(string country, string city)
        {
            var weather = _weatherService.GetWeather(country, city);
            return Ok(weather);
        }
    }
}