using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.EmissionsCalculatorBuilders
{
    public interface IEmissionsCalculatorBuilder
    {
        IEmissionsCalculator Build();
        void BuildParametersCalculator();
        void BuildDimensionlessCoefficientsCalculator();
        void BuildDistanceCoefficientsCalculator();
        void BuildDistanceCalculator();
    }
}