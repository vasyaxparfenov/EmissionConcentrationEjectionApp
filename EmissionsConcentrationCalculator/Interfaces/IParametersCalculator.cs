namespace EmissionsConcentrationCalculator.Interfaces
{
    public interface IParametersCalculator
    {
        ICalculateOptions Options { get; set; }
        double CalculateF();
        double CalculateFe();
        double CalculateVm();
        double CalculateVmHatch();

    }
}