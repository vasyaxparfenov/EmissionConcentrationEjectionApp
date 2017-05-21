using EmissionsCalculator.Interfaces;

namespace EmissionsCalculator.Calculators
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public IDimensionlessCoefficientsCalculator DimensionlessCoefficients { get; set; }

        public DistanceCalculator(IDimensionlessCoefficientsCalculator dimensionlessCoefficients)
        {
            DimensionlessCoefficients = dimensionlessCoefficients;
        }
        public double CalculateDistanceForGas()
        {
            var h = DimensionlessCoefficients.Parameters.Options.SourceHeight;
            var d = DimensionlessCoefficients.CalculateD();
            return  h * d;
        }

        public double CalculateDistanceForSolidParticles()
        {
            var h = DimensionlessCoefficients.Parameters.Options.SourceHeight;
            var d = DimensionlessCoefficients.CalculateD();
            var f = DimensionlessCoefficients.CalculateF();
            return (5 - f) / 4.0 * h * d;
        }
    }
}