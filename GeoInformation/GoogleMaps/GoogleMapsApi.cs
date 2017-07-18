using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using GeoInformation.InformationTypes;

namespace GeoInformation.GoogleMaps
{
    public class GoogleMapsApi : IMapInformation
    {
        public IGoogleMapParameters Parameters { get; set; }

        public static string GoogleMapsApiUrl = "https://maps.googleapis.com/maps/api";

        private readonly string _googleApiKey;

        private static readonly Dictionary<MapFormat, string> Format = new Dictionary<MapFormat, string>
        {
            { MapFormat.JPEG, "jpg" },
            { MapFormat.GIF, "gif" },
            { MapFormat.PNG, "png" }
        };

        private static readonly Dictionary<MapType, string> Type = new Dictionary<MapType, string>
        {
            {MapType.Hybrid, "hybrid" },
            {MapType.Roadmap, "roadmap" },
            {MapType.Satelite, "satelite" },
            {MapType.Terrain, "terrain" }
        };

        public GoogleMapsApi(string googleApiKey, IGoogleMapParameters parameters)
        {
            _googleApiKey = googleApiKey;
            Parameters = parameters;
        }

        /// <summary>
        /// Returns either a Stream, witch contains bytes of image, if status code of response is 200, or null in opposite cases
        /// </summary>
        /// <returns></returns>
        public async Task<Stream> GetStaticMapImage()
        {
            using (var http = new HttpClient())
            {
                var requestUrl =
                    $"{GoogleMapsApiUrl}/staticmap?center={Parameters.Center}&zoom={Parameters.Zoom}&size=640x640&scale=2&maptype={Type[Parameters.Type]}&format={Format[Parameters.Format]}&key={_googleApiKey}";
                var response = await http.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadAsStreamAsync();
            }
        }
    }
}