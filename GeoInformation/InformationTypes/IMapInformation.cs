using System.IO;
using System.Threading.Tasks;

namespace GeoInformation.InformationTypes
{
    public interface IMapInformation
    {
        Task<Stream> GetStaticMapImage();
    }
}