namespace EmissionsCalculator.CalculatorTypes
{
    public interface IDimensionlessCoefficientsCalculator
    {
        /// <summary>
        /// Calculator responsible for calculating needed parameters
        /// </summary>
        IParametersCalculator Parameters { get;}
        /// <summary>
        /// Calculates M coefficient based on parameters
        /// </summary>
        /// <returns> M coefficient </returns>
        double CalculateM();
        /// <summary>
        /// Calculate D coefficient based on parameters
        /// </summary>
        /// <returns></returns>
        double CalculateD();
        /// <summary>
        /// Calculates N coefficient based on parameters
        /// </summary>
        /// <returns></returns>
        double CalculateN();
        /// <summary>
        /// Calculates F coefficient based on parameters
        /// </summary>
        /// <returns></returns>
        double CalculateF();
    }
}