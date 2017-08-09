using EmissionsCalculator.CalculatorTypes;
using EmissionsCalculator.EmissionsCalculatorBuilders;

namespace EmissionsCalculator
{
    public class EmissionsCalculatorService : ICalculatorService
    {
        public IEmissionsCalculator CreateEmissionsCalculator(IEmissionsCalculatorBuilder builder)
        {
            builder.BuildParametersCalculator();
            builder.BuildDimensionlessCoefficientsCalculator();
            builder.BuildDistanceCoefficientsCalculator();
            builder.BuildDistanceCalculator();
            return builder.Build();
        }
    }
}