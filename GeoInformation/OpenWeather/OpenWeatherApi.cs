using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GeoInformation.InformationTypes;
using Newtonsoft.Json.Linq;

namespace GeoInformation.OpenWeather
{
    public class OpenWeatherApi : IWeatherInformation
    {
        public static string OpenWeatherApiUrl = "http://api.openweathermap.org/data";
        
        private readonly string _versionOfOpenWeatherApi;

        private readonly string _openWeatherApiKey;
        public IOpenWeatherParameters Parameters { get; set; }

        public OpenWeatherApi(IOpenWeatherParameters parameters, string versionOfOpenWeatherApi, string openWeatherApiKey)
        {
            Parameters = parameters;
            _versionOfOpenWeatherApi = versionOfOpenWeatherApi;
            _openWeatherApiKey = openWeatherApiKey;
        }

        public async Task<HttpResponseMessage> GetWeatherInforamtion()
        {
            using (var http = new HttpClient())
            {
                var searchRequest =
                    Parameters.Coordinates.longtitude.HasValue && Parameters.Coordinates.latitude.HasValue
                        ? $"lat={Parameters.Coordinates.latitude}&lon={Parameters.Coordinates.longtitude}" : $"q={Parameters.CityName}";
                var response =
                    await http.GetAsync(
                        $"{OpenWeatherApiUrl}/{_versionOfOpenWeatherApi}/weather?{searchRequest}&appid={_openWeatherApiKey}");
                return response;
            }
        }

        /// <summary>
        /// Returns either OpenWeatherWindInformation type object if status code of response is 200, or null in opposite cases 
        /// </summary>
        /// <returns></returns>
        public async Task<OpenWeatherWindInformation?> GetWindInforamtion()
        {
            var response = await GetWeatherInforamtion();
            if (!response.IsSuccessStatusCode) return null;
            var contentAsString = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(contentAsString);
            return json["wind"].ToObject<OpenWeatherWindInformation>();
        }
    }
}