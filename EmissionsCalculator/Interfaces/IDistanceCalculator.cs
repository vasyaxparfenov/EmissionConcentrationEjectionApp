namespace EmissionsCalculator.Interfaces
{
    public interface IDistanceCalculator
    {
        /// <summary>
        /// Calculator needed for calculating needed dimensionless coefficients
        /// </summary>
        IDimensionlessCoefficientsCalculator DimensionlessCoefficients { get; set; }
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
    }
}