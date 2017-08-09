namespace EmissionsCalculator.CalculatorTypes
{
    public interface IDistanceCoefficientsCalculator
    {
        /// <summary>
        /// Actual wind speed
        /// </summary>
        double WindSpeed { get; set; }
        /// <summary>
        /// Calculator needed for calculating needed dimensionless coefficients
        /// </summary>
        IDimensionlessCoefficientsCalculator DimensionlessCoefficients { get; }
        /// <summary>
        /// Calculates dangerous wind speed
        /// </summary>
        /// <returns></returns>
        double CalculateUm();
        /// <summary>
        /// Calculates p coefficient
        /// </summary>
        /// <returns></returns>
        double CalculateP();
        /// <summary>
        /// Calculates difference between actual wind speed and dangerous wind speed
        /// </summary>
        /// <returns></returns>
        double CalculateWindSpeedDifference();
    }
}