using System;

namespace GeoInformation.OpenWeather
{
    public interface IOpenWeatherParameters
    {
        /// <summary>
        /// City name parameter, optional if coordinates are mentioned
        /// </summary>
        string CityName { get; set; }
        /// <summary>
        /// Geographical coordinates paramter, optional if city name is mentioned
        /// </summary>
        (double? longtitude, double? latitude) Coordinates { get; set; }

    }
}