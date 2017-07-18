using System;
using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.Calculators
{
    public class ParametersCalculator : IParametersCalculator
    {
        public IParametersOptions Options { get; set; }

        public ParametersCalculator(IParametersOptions options)
        {
            Options = options;
        }
        public double CalculateF() => 1000 * Math.Pow(Options.OutcomeSpeed, 2) * Options.SourceMouthDiameter /
                                              (Math.Pow(Options.SourceHeight, 2) * Options.TemperatureDelta);
        
        public double CalculateFe() => 800 * Math.Pow(CalculateVmHatch(), 3);

        public double CalculateVm() => 0.65 * Math.Pow(Options.OutcomeSpeed * (Math.PI * Math.Pow(Options.SourceMouthDiameter, 2) / 4)*130/180,
                                           1.0 / 3);

        public double CalculateVmHatch() => 1.3 * Options.OutcomeSpeed * Options.SourceMouthDiameter / Options.SourceHeight;
    }
}