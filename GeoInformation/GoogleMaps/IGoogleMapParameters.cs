namespace GeoInformation.GoogleMaps
{
    public interface IGoogleMapParameters
    {
        /// <summary>
        /// Parameter can be either name or {latitude,longitude} coordinates of the place
        /// </summary>
        string Center { get; set; }
        /// <summary>
        /// Parameter is for a scale determination
        /// </summary>
        string Zoom { get; set; }
        /// <summary>
        /// Parameter is for an image format
        /// </summary>
        MapFormat Format { get; set; }
        /// <summary>
        /// Parameter is for map type 
        /// </summary>
        MapType Type { get; set; }
    }
}