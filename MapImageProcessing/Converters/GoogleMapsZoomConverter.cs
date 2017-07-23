using System;
using System.Collections.Generic;

namespace MapImageProcessing.Converters
{
    public class GoogleMapsZoomConverter : IZoomConverter
    {
        private static readonly Dictionary<string, double> ZoomToScale = new Dictionary<string, double>
        {
            {"16", 1.25},
            {"15", 2.5 },
            {"14", 5 },
            {"13", 10 },
            { "12", 20},
            {"11", 40 },
            {"10", 80 },
            {"9", 160 }
        };
        public double GetMeterPerPixel(string zoom)
        {
            ZoomToScale.TryGetValue(zoom, out double scale);
            if(Math.Abs(scale) < Double.Epsilon) { throw new ArgumentException("There is no such zoom available in Converter");}
            return scale;
        }
    }
}