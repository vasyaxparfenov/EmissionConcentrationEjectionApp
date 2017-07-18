namespace EmissionsCalculator.CalculatorTypes
{   
    
    public interface IParametersCalculator
    {
        /// <summary>
        /// Options needed for calculating parameters
        /// </summary>
        IParametersOptions Options { get; set; }

        /// <summary>
        /// Calculates F parameter based on implemented formula.
        /// </summary>
        /// <returns>
        /// Returns F parameter 
        /// </returns>
        double CalculateF();
        /// <summary>
        /// Calculates Fe parameter based on implemented formula
        /// </summary>
        /// <returns>
        /// Returns Fe parameter
        /// </returns>
        double CalculateFe();
        /// <summary>
        /// Calculates Vm parameter based on implemented formula
        /// </summary>
        /// <returns>
        /// Returns Vm parameter
        /// </returns>
        double CalculateVm();
        /// <summary>
        /// Calculates Vm hatch parameter based on implemented fromula
        /// </summary>
        /// <returns></returns>
        double CalculateVmHatch();

    }
}