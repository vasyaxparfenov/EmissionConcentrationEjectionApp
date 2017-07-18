using System.Drawing;
using System.Net.Http;
using GeoInformation.GoogleMaps;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoInformationTests
{
    
    [TestClass]
    public class GoogleMapsApiTests
    {
        [TestMethod]
        public void GetStaticMapGeneralTest()
        {
            var parameters = new MapParameters
            {
                Center = "Odessa",
                Format = MapFormat.JPEG,
                Type = MapType.Roadmap,
                Zoom = "14"
            };

            var googleMapApi = new GoogleMapsApi("AIzaSyAc8NoMPpWFiILAS5HQ3jMjFoFVAJN9Ma4", parameters);
            var response = googleMapApi.GetStaticMapImage().Result;
            Assert.IsNotNull(response);
            
        }
        
    }
}