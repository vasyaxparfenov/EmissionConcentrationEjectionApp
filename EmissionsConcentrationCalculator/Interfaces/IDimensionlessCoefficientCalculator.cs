namespace EmissionsConcentrationCalculator.Interfaces
{
    public interface IDimensionlessCoefficientCalculator
    {
        IParametersCalculator Parameters { get; set; }
        double CalculateM();
        double CalculateD();
        double CalculateN();
    }
}