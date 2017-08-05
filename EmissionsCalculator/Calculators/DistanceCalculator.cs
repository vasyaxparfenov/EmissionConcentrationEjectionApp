using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.Calculators
{
    public class DistanceCalculator : IDistanceCalculator, IParameterised
    {
        private IParametersOptions _options;
        public IParametersOptions Options
        {
            get => DistanceCoefficients?.DimensionlessCoefficients?.Parameters?.Options ?? _options;
            set
            {
                if (DistanceCoefficients?.DimensionlessCoefficients?.Parameters?.Options != null)
                {
                    DistanceCoefficients.DimensionlessCoefficients.Parameters.Options = value;
                }
                else
                {
                    _options = value;
                }
            }
        }

        public IDistanceCoefficientsCalculator DistanceCoefficients { get; set; }

        public DistanceCalculator(IDistanceCoefficientsCalculator distnaceCoefficients)
        {
            DistanceCoefficients = distnaceCoefficients;
        }


        public double CalculateDistanceForGas()
        {
            var h = Options.SourceHeight;
            var d = DistanceCoefficients.DimensionlessCoefficients.CalculateD();
            return  h * d;
        }

        public double CalculateDistanceForSolidParticles()
        {
            var h = Options.SourceHeight;
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