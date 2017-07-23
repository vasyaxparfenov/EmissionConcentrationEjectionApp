using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using MapImageProcessing.Converters;
using MapImageProcessing.ProcessorsTypes;

namespace MapImageProcessing.Processors
{
    public class TemporaryImageProcessor : IMapImageProcessor
    {
        public IZoomConverter ZoomConverter { get; set; }
        public TemporaryImageProcessor(IZoomConverter converter)
        {
            ZoomConverter = converter;
        }
        public Bitmap DrawArea(Stream image, string zoom, double gasAreaRadius, double solidParticlesAreaRadius)
        {
            var source = new Bitmap(image);
            var scale = ZoomConverter.GetMeterPerPixel(zoom);
            var radiusForGasInPixels = ConvertToFloat(gasAreaRadius / scale);
            var radiusForSolidParticlesInPixels = ConvertToFloat(solidParticlesAreaRadius / scale);
            var graphic = Graphics.FromImage(source);
            graphic.DrawEllipse(new Pen(Color.Red, 5), Convert.ToSingle(source.Height/2) - radiusForGasInPixels, Convert.ToSingle(source.Width/2) - radiusForGasInPixels, radiusForGasInPixels*2, radiusForGasInPixels*2);
            graphic.DrawEllipse(new Pen(Color.Blue, 5), Convert.ToSingle(source.Height / 2) - radiusForSolidParticlesInPixels, Convert.ToSingle(source.Width / 2) - radiusForSolidParticlesInPixels, radiusForSolidParticlesInPixels * 2, radiusForSolidParticlesInPixels * 2);

            return source;

            float ConvertToFloat(double value)
            {
                var convertedValue = Convert.ToSingle(value);
                if (float.IsPositiveInfinity(convertedValue))
                {
                    return float.MaxValue;
                }
                if (float.IsNegativeInfinity(convertedValue))
                {
                    return float.MinValue;
                }
                return convertedValue;
            }
        }

        public async Task<Bitmap> DrawAreaAsync(Stream image, string zoom, double gasAreaRadius, double solidParticlesAreaRadius)
        {
            return await Task.Factory.StartNew(() => DrawArea(image, zoom, gasAreaRadius, solidParticlesAreaRadius));
        }
    }
}