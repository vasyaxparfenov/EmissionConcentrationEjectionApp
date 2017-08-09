using EmissionsCalculator.CalculatorTypes;
using EmissionsCalculator.EmissionsCalculatorBuilders;

namespace EmissionsCalculator
{
    public interface ICalculatorService
    {
        IEmissionsCalculator CreateEmissionsCalculator(IEmissionsCalculatorBuilder builder);
    }
}