using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmissionsConcentrationCalculator.Calculators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmissionsConcentrationAppTest
{
    [TestClass]
    public class DimensionlessCoefficientCalculatorTests
    {
        private readonly DimensionlessCoefficientCalculator _dimensionlessCoefficientCalculator = new DimensionlessCoefficientCalculator
        {
            Parameters = new ParametersCalculator
            {
                Options = new TestCalculateOptions
                {
                    OutcomeSpeed = 25,
                    SourceHeight = 180,
                    SourceMouthDiameter = 7,
                    TemperatureDelta = 130

                }
            }
        };

        [TestMethod]
        public void CalculateMTest()
        {
            Assert.IsTrue(Math.Abs(Math.Round(_dimensionlessCoefficientCalculator.CalculateM(), 3) - 0.703) < Double.Epsilon);
        }

        [TestMethod]
        public void CalculateDTest()
        {
            Assert.IsTrue(Math.Abs(Math.Round(_dimensionlessCoefficientCalculator.CalculateD(), 2) - 21.56) < Double.Epsilon);
        }

        [TestMethod]

        public void CalculateNTest()
        {
            Assert.IsTrue(Math.Abs(_dimensionlessCoefficientCalculator.CalculateN() - 1) < Double.Epsilon);
        }
    }

}
