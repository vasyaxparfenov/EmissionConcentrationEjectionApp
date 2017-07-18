namespace EmissionsCalculator.CalculatorTypes
{
   public interface IParametersOptions
    {
        /// <summary>
        /// Outcome speed of gas-air mixture (meter per second)
        /// </summary>
        double OutcomeSpeed { get; set; }
        /// <summary>
        /// Temperature difference between gas-air mixture temperature and atmospheric air
        /// </summary>
        double TemperatureDelta { get; set; }
        /// <summary>
        /// Height above ground level of outcome source  
        /// </summary>
        double SourceHeight { get; set; }
        /// <summary>
        /// Diameter of source muzzle
        /// </summary>
        double SourceMouthDiameter { get; set; }
        /// <summary>
        /// Coefficient of outcome filter
        /// </summary>
        double FilterCoefficient { get; set; }
    }
}
