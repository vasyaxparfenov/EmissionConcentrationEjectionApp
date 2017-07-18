using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculatorTests
{
    public class TestCalculateOptions : IParametersOptions

    {
        public double OutcomeSpeed { get; set; }
        public double TemperatureDelta { get; set; }
        public double SourceHeight { get; set; }
        public double SourceMouthDiameter { get; set; }
        public double FilterCoefficient { get; set; }
    }
}
