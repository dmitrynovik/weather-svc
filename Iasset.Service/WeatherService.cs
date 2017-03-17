using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Iasset.Service.DataModel;
using Iasset.Service.WeatherProxy;
using Newtonsoft.Json;

namespace Iasset.Service
{
    public class WeatherService
    {
        private readonly GlobalWeatherSoapClient _client;
        private readonly string _apiKey;

        public WeatherService(GlobalWeatherSoapClient client, string apiKey)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentNullException(nameof(apiKey));

            _client = client;
            _apiKey = apiKey;
        }

        public async Task<ICollection<string>> GetCitiesByCountry(string country)
        {
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));

            var payload = await GetCitiesOfCountry(country);
            if (string.IsNullOrWhiteSpace(payload))
                return new string[0];

            var data = Serializer.Deserialize<CountryDataSet>(payload);

            return data.Table.Select(x => x.City)
                .Distinct()
                .OrderBy(x => x)
                .ToArray();
        }

        public WeatherModel GetWeather(string country, string city)
        {
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city));

            var content = DownloadOpenWebMapContent(country, city);
            var root = JsonConvert.DeserializeObject<WeatherRoot>(content);
            return new WeatherModel(root);
        }

        protected virtual async Task<string> GetCitiesOfCountry(string country)
        {
            return await _client.GetCitiesByCountryAsync(country);
        }

        protected virtual string DownloadOpenWebMapContent(string country, string city)
        {
            var url = $"http://api.openweathermap.org/data/2.5/weather?q={city}.{country}&appid={_apiKey}";
            var client = new WebClient();
            using (var stream = client.OpenRead(url))
            {
                if (stream == null)
                    throw new IOException($"cannot read from {url}");

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
