using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace MapImageProcessing.ProcessorsTypes
{
    public interface IMapImageProcessor
    {
        Bitmap DrawArea(Stream image, string zoom, double gasAreaRadius, double solidParticlesAreaRadius);
        Task<Bitmap> DrawAreaAsync(Stream image, string zoom, double gasAreaRadius, double solidParticlesAreaRadius);

    }
}