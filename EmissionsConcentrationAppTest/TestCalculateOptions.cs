using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmissionsConcentrationCalculator;

namespace EmissionsConcentrationAppTest
{
    public class TestCalculateOptions : ICalculateOptions
    {
        public double OutcomeSpeed { get; set; }
        public double TemperatureDelta { get; set; }
        public double SourceHeight { get; set; }
        public double SourceMouthDiameter { get; set; }
    }
}
