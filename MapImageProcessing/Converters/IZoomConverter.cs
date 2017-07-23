namespace MapImageProcessing.Converters
{
    public interface IZoomConverter
    {
        double GetMeterPerPixel(string zoom);
    }
}