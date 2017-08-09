using System;
using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.Calculators
{
    public class TemporaryEmissionsCalculator : IEmissionsCalculator
    {
        public IDistanceCalculator Distance { get; }

        public TemporaryEmissionsCalculator(IDistanceCalculator distance)
        {
            Distance = distance;
        }
        public DistanceBasedOnWind CalculateDistanceOfPollution()
        {
            return Distance.CalculateDistanceBasedOnWindSpeed();
        }

        public void SetOptions(IParametersOptions options)
        {
            Distance.DistanceCoefficients.DimensionlessCoefficients.Parameters.Options = options;
        }

        public void ModifyOptions(Action<IParametersOptions> optionsSetter)
        {
            optionsSetter(Distance.DistanceCoefficients.DimensionlessCoefficients.Parameters.Options);
        }

        public void SetWindSpeed(double windSpeed)
        {
            Distance.DistanceCoefficients.WindSpeed = windSpeed;
        }
    }
}