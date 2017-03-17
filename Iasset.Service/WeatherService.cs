using System;
using System.Threading.Tasks;
using Iasset.Service.WeatherProxy;

namespace Iasset.Service
{
    public class WeatherService
    {
        private readonly GlobalWeatherSoapClient _client;

        public WeatherService(GlobalWeatherSoapClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            _client = client;
        }

        public async Task<string> GetCitiesByCountry(string country)
        {
            return await _client.GetCitiesByCountryAsync(country);
        }
    }
}
