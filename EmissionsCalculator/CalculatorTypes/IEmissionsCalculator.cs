using System;

namespace EmissionsCalculator.CalculatorTypes
{
    public interface IEmissionsCalculator
    {
        IDistanceCalculator Distance { get; }
        DistanceBasedOnWind CalculateDistanceOfPollution();
        void SetOptions(IParametersOptions options);
        void ModifyOptions(Action<IParametersOptions> optionsSetter);
        void SetWindSpeed(double windSpeed);
        
    }
}