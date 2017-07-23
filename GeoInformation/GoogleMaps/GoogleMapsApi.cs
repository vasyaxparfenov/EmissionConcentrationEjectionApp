using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GeoInformation.InformationTypes;

namespace GeoInformation.GoogleMaps
{
    public class GoogleMapsApi : IMapInformation
    {
        public IGoogleMapParameters Parameters { get; set; }

        public static string GoogleMapsApiUrl = "https://maps.googleapis.com/maps/api";
        /// <summary>
        /// Parameter is for a scale determination
        /// </summary>
        public string Zoom { get; private set; }

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
            {MapType.Satellite, "satellite" },
            {MapType.Terrain, "terrain" }
        };

        private static readonly Dictionary<DistanceRange, string> ZoomFromDistance = new Dictionary<DistanceRange, string>
        {
            {new DistanceRange(0,700), "16"},
            {new DistanceRange(700, 1500),"15"},
            {new DistanceRange(1500, 3100),"14"},
            {new DistanceRange(3100, 6300), "13"},
            {new DistanceRange(6300, 12700), "12"},
            {new DistanceRange(12700, 25500), "11" },
            {new DistanceRange(25500, 51100), "10"  },
            {new DistanceRange(51100, 102300), "9"  }

        };

        public GoogleMapsApi(string googleApiKey, IGoogleMapParameters parameters)
        {
            _googleApiKey = googleApiKey;
            Parameters = parameters;
            Zoom = ZoomFromDistance.Values.Last();
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
                    $"{GoogleMapsApiUrl}/staticmap?center={Parameters.Center}&zoom={Zoom}&size=640x640&scale=2&maptype={Type[Parameters.Type]}&format={Format[Parameters.Format]}&key={_googleApiKey}";
                var response = await http.GetAsync(requestUrl);
                if (!response.IsSuccessStatusCode) return null;
                return await response.Content.ReadAsStreamAsync();
            }
        }

        public void SetZoomFromDistance(double distance)
        {
            foreach (var zoom in ZoomFromDistance)
            {
                if (zoom.Key.Between(distance))
                {
                    Zoom = zoom.Value;
                }
            }
        }
    }
}