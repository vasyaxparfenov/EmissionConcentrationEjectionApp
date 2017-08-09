namespace EmissionsCalculator.CalculatorTypes
{
    public interface IDistanceCalculator
    {   
        /// <summary>
        /// Calculator needed for calculating coefficients for distance calculations
        /// </summary>
        IDistanceCoefficientsCalculator DistanceCoefficients { get; }
        /// <summary>
        /// Calculates distance of max outcome for gas-likes substances
        /// </summary>
        /// <returns></returns>
        double CalculateDistanceForGas();
        /// <summary>
        /// Calculates distance of max outcome for solid particles 
        /// </summary>
        /// <returns></returns>
        double CalculateDistanceForSolidParticles();
        /// <summary>
        /// Calculates distance of max outcome based on wind speed for gas and for solid particles
        /// </summary>
        /// <returns></returns>
        DistanceBasedOnWind CalculateDistanceBasedOnWindSpeed();

    }
}