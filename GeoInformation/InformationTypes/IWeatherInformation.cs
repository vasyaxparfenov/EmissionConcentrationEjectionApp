using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeoInformation.InformationTypes
{
    public interface IWeatherInformation
    {
        /// <summary>
        /// Returns a HttpResponseMessage, whitch Content contains information about weather  
        /// </summary>
        /// <returns></returns>
        Task<HttpResponseMessage> GetWeatherInforamtion();
    }
}