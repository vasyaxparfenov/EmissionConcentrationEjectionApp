using System;
using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.Calculators
{
    public class DistanceCoefficientsCalculator : IDistanceCoefficientsCalculator
    {
        public double WindSpeed { get; set; }
        public IDimensionlessCoefficientsCalculator DimensionlessCoefficients { get; set; }

        public DistanceCoefficientsCalculator(IDimensionlessCoefficientsCalculator dimensionlessCoefficients )
        {
            DimensionlessCoefficients = dimensionlessCoefficients;
        }

        public DistanceCoefficientsCalculator(IDimensionlessCoefficientsCalculator dimensionlessCoefficients, double windSpeed) : this(dimensionlessCoefficients)
        {
            WindSpeed = windSpeed;
        }
        public double CalculateUm()
        {
            var f = DimensionlessCoefficients.Parameters.CalculateF();
            if (f < 100)
            {
                var vm = DimensionlessCoefficients.Parameters.CalculateVm();
                if (vm <= 0.5)
                {
                    return 0.5;
                }
                if (vm > 0.5 && vm <= 2)
                {
                    return vm;
                }
                return vm*(1 + 0.12 * Math.Sqrt(f));
            }
            var vmHatch = DimensionlessCoefficients.Parameters.CalculateVmHatch();
            if (vmHatch <= 0.5)
            {
                return 0.5;
            }
            if (vmHatch > 0.5 && vmHatch <= 2)
            {
                return vmHatch;
            }
            return 2.2 * vmHatch;
        }

        public double CalculateP()
        {
            var difference = CalculateWindSpeedDifference();
            if (difference <= 0.25)
            {
                return 3;
            }
            if (difference > 0.25 && difference <= 1)
            {
                return 8.43 * Math.Pow(1 - difference, 3) + 1;
            }
            return 0.32 * difference + 0.68;
        }

        public double CalculateWindSpeedDifference()
        {
            return WindSpeed / CalculateUm();
        }
    }
}