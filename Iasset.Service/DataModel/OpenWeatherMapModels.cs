using System.Collections.Generic;
using System.Linq;
using Iasset.Service.Extensions;

namespace Iasset.Service.DataModel
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
    }

    public class Wind
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    public class Clouds
    {
        public int All { get; set; }
    }

    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public double Message { get; set; }
        public string Country { get; set; }
        public int Sunrise { get; set; }
        public int Sunset { get; set; }
    }

    public class WeatherContainer
    {
        public Coord Coord { get; set; }
        public ICollection<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class WeatherModel
    {
        public WeatherModel(WeatherContainer root)
        {
            var weather = root.Weather.FirstOrDefault();

            Location = $"{root.Coord?.Lat},{root.Coord?.Lon}";
            Time = DateTimeExtensions.FromUnixTime(root.Dt).ToString("dd-MMM-yyyy HH:mm:ss");
            Wind = $"{root.Wind?.Deg}° {root.Wind?.Speed}kph";
            Visibility = $"{root.Visibility}m";
            Sky = string.IsNullOrEmpty(weather?.Description) ? $"{weather?.Main}" : $"{weather?.Main} ({weather.Description})";
            Temperature = $"{root.Main.Temp - 273:F2}°C";
            Humidity = $"{root.Main.Humidity}%";
            Pressure = $"{root.Main.Pressure}hPa";
            City = root.Name;
            Country = root.Sys.Country;
        }

        public string Location { get; }
        public string Time { get; }
        public string Wind { get; }
        public string Visibility { get; }
        public string Sky { get; set; }
        public string Humidity { get; private set; }
        public string Pressure { get; set; }
        public string Temperature { get; set; }
        public string Country { get; set; }
        public object City { get; set; }
    }
}
