using System;
using EmissionsCalculator.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmissionsCalculatorTests
{
    [TestClass]
    public class ParametersCalculatorTests
    {
        private readonly ParametersCalculator _calculator = new ParametersCalculator(new TestCalculateOptions
        {
            OutcomeSpeed = 25,
            SourceHeight = 180,
            SourceMouthDiameter = 7,
            TemperatureDelta = 130

        });


        [TestMethod]
        public void CalculateFeTest()
        {
            Assert.IsTrue(Math.Abs(Math.Round(_calculator.CalculateFe(), 2) - 1615.16) < Double.Epsilon);
        }

        [TestMethod]
        public void CalculateFTest()
        {
            Assert.IsTrue(Math.Abs(Math.Round(_calculator.CalculateF(), 2) - 1.04) < Double.Epsilon);
        }

        [TestMethod]
        public void CalculateVmTest()
        {
            Assert.IsTrue(Math.Abs(Math.Round(_calculator.CalculateVm(), 2) - 5.76) < Double.Epsilon);
        }

        [TestMethod]
        public void CalculateVmHatchTest()
        {
            Assert.IsTrue(Math.Abs(Math.Round(_calculator.CalculateVmHatch(), 2) - 1.26) < Double.Epsilon);
        }

    }

}
