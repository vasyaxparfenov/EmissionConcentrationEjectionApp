using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.Calculators
{
    public class DistanceCalculator : IDistanceCalculator
    {
        public IDistanceCoefficientsCalculator DistanceCoefficients { get; set; }
        public DistanceCalculator(IDistanceCoefficientsCalculator distnaceCoefficients)
        {
            DistanceCoefficients = distnaceCoefficients;
        }


        public double CalculateDistanceForGas()
        {
            var h = DistanceCoefficients.DimensionlessCoefficients.Parameters.Options.SourceHeight;
            var d = DistanceCoefficients.DimensionlessCoefficients.CalculateD();
            return  h * d;
        }

        public double CalculateDistanceForSolidParticles()
        {
            var h = DistanceCoefficients.DimensionlessCoefficients.Parameters.Options.SourceHeight;
            var d = DistanceCoefficients.DimensionlessCoefficients.CalculateD();
            var f = DistanceCoefficients.DimensionlessCoefficients.CalculateF();
            return (5 - f) / 4.0 * h * d;
        }

        public DistanceBasedOnWind CalculateDistanceBasedOnWindSpeed()
        {
            var p = DistanceCoefficients.CalculateP();
            var gas = p * CalculateDistanceForGas();
            var solidParticles = p * CalculateDistanceForSolidParticles();
            return new DistanceBasedOnWind
            {
                Gas = gas,
                SolidParticles = solidParticles
            };
        }
    }
}