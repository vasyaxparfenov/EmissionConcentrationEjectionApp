namespace GeoInformation.GoogleMaps
{
    public struct DistanceRange
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; }

        public DistanceRange(double min, double max)
        {
            Minimum = min;
            Maximum = max;
        }
        public bool Between(double distance)
        {
            return Minimum <= distance && distance <= Maximum;
        }
    }
}