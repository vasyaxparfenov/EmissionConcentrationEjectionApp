using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoInformation.GoogleMaps;

namespace GeoInformationTests
{
    public class MapParameters : IGoogleMapParameters
    {
        public string Center { get; set; }
        public string Zoom { get; set; }
        public MapFormat Format { get; set; }
        public MapType Type { get; set; }
    }
}
