using System;
using System.Collections.Generic;
using System.Text;

namespace EmissionsConcentrationCalculator
{
   public interface ICalculateOptions
    {
        double OutcomeSpeed { get; set; }
        double TemperatureDelta { get; set; }
        double SourceHeight { get; set; }
        double SourceMouthDiameter { get; set; }
    }
}
