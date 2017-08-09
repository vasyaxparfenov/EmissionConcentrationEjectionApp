using EmissionsCalculator.Calculators;
using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.EmissionsCalculatorBuilders
{
    public class TemporaryEmissionsCalculatorBuilder : IEmissionsCalculatorBuilder
    {

        private readonly IParametersOptions _options;

        private IParametersCalculator _parametersCalculator;

        private IDimensionlessCoefficientsCalculator _dimensionlessCoefficientsCalculator;

        private IDistanceCoefficientsCalculator _distanceCoefficientsCalculator;

        private IDistanceCalculator _distanceCalculator;
        

        public TemporaryEmissionsCalculatorBuilder(IParametersOptions options)
        {
            _options = options;
        }

        public IEmissionsCalculator Build()
        {
            return new TemporaryEmissionsCalculator(_distanceCalculator);
        }

        public void BuildParametersCalculator()
        {
            _parametersCalculator = new ParametersCalculator(_options);
        }

        public void BuildDimensionlessCoefficientsCalculator()
        {
            _dimensionlessCoefficientsCalculator = new DimensionlessCoefficientsCalculator(_parametersCalculator);
        }

        public void BuildDistanceCoefficientsCalculator()
        {
            _distanceCoefficientsCalculator = new DistanceCoefficientsCalculator(_dimensionlessCoefficientsCalculator);
        }

        public void BuildDistanceCalculator()
        {
            _distanceCalculator = new DistanceCalculator(_distanceCoefficientsCalculator);
        }
    }
}