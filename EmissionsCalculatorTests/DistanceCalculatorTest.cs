using System;
using EmissionsCalculator.Calculators;
using EmissionsCalculator.CalculatorTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmissionsCalculatorTests
{
    [TestClass]
    public class DistanceCalculatorTest
    {
        public IDistanceCalculator Calculator = new DistanceCalculator(new DimensionlessCoefficientsCalculator(new ParametersCalculator(new TestCalculateOptions())));

        public void ConfigureCalculatorForFirstTest()
        {
            Calculator.DimensionlessCoefficients.Parameters.Options.SourceHeight = 180;
            Calculator.DimensionlessCoefficients.Parameters.Options.FilterCoefficient = 95;
            Calculator.DimensionlessCoefficients.Parameters.Options.OutcomeSpeed = 25;
            Calculator.DimensionlessCoefficients.Parameters.Options.SourceMouthDiameter = 7;
            Calculator.DimensionlessCoefficients.Parameters.Options.TemperatureDelta = 130;
        }
        [TestMethod]
        public void CalculateDistanceForGasTest()
        {
            ConfigureCalculatorForFirstTest();
            Assert.IsTrue(Math.Abs(Math.Round(Calculator.CalculateDistanceForGas(), 1) - 3880.6) < Double.Epsilon);
        }
        [TestMethod]
        public void CalculateDistanceForSolidParticles()
        {
            ConfigureCalculatorForFirstTest();
            Assert.IsTrue(Math.Abs(Math.Round(Calculator.CalculateDistanceForSolidParticles(),1) - 2910.4) < Double.Epsilon);
        }
    }
}