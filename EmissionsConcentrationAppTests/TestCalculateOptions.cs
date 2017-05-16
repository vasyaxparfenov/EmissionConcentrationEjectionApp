using EmissionsConcentrationCalculator;

namespace EmissionsConcentrationAppTests
{
    public class TestCalculateOptions : ICalculateOptions
    {
        public double OutcomeSpeed { get; set; }
        public double TemperatureDelta { get; set; }
        public double SourceHeight { get; set; }
        public double SourceMouthDiameter { get; set; }
    }
}
