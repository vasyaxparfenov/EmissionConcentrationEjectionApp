using System;
using EmissionsCalculator.CalculatorTypes;

namespace EmissionsCalculator.Calculators
{
    public class DimensionlessCoefficientsCalculator : IDimensionlessCoefficientsCalculator, IParameterised
    {
        private IParametersOptions _options;

        public IParametersOptions Options
        {
            get => Parameters?.Options ?? _options;
            set
            {
                if (Parameters?.Options != null)
                {
                    Parameters.Options = value;
                }
                _options = value;
            }
        }

        public IParametersCalculator Parameters { get;}


        public DimensionlessCoefficientsCalculator(IParametersCalculator parameters)
        {
            Parameters = parameters;
        }
        public double CalculateM()
        {
            var f = Parameters.CalculateF();
            if (f < 100)
            {
                return 1.0 / (0.67 + 0.4 * Math.Sqrt(f) + 0.34 * Math.Pow(f, 1.0 / 3));
            }
            return 1.47 / 3 * Math.Sqrt(f);
        }

        public double CalculateD()
        {
            var f = Parameters.CalculateF();
            var vm = Parameters.CalculateVm();

            if (f > 100 || Options.TemperatureDelta < Double.Epsilon) // second condition ΔT ≈ 0
            {
                var vmhatch = Parameters.CalculateVmHatch();
                if (vmhatch <= 0.5)
                {
                    return 5.7;
                }

                if (vmhatch > 0.5 && vmhatch <= 2)
                {
                    return 11.4 * vmhatch;
                }

                return 16 * Math.Sqrt(vm);
            }

            if (vm <= 0.5)
            {
                var fe = Parameters.CalculateFe();
                return 2.48 * (1 * +0.28 * Math.Pow(fe, 1.0 / 3));
            }

            if (vm > 0.5 && vm <= 2)
            {
                return 4.951 * vm * (1 + 0.28 * Math.Pow(f, 1.0 / 3));
            }

            return 7 * Math.Sqrt(vm) * (1 + 0.28 * Math.Pow(f, 1.0 / 3));
            
        }

        public double CalculateN()
        {
            var vm = Parameters.CalculateVm();
            if (vm < 0.5)
            {
                return 4.4*vm;
            }
            if (vm >= 0.5 && vm < 2)
            {
                return 0.532 * Math.Pow(vm, 2) - 2.13 * vm + 3.13;
            }

            return 1;

        }

        public double CalculateF()
        {
            if (Options.FilterCoefficient >= 90)
            {
                return 2;
            }
            if (Options.FilterCoefficient >= 75 && Options.FilterCoefficient < 90)
            {
                return 2.5;
            }
            return 3;
        }

    }
}