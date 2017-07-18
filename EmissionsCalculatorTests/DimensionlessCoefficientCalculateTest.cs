using System;
using System.Security.Cryptography.X509Certificates;
using EmissionsCalculator.Calculators;
using EmissionsCalculator.CalculatorTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmissionsCalculatorTests
{
    [TestClass]
    public class DimensionlessCoefficientCalculatorTests
    {
        private readonly IDimensionlessCoefficientsCalculator _dimensionlessCoefficientsCalculator = new DimensionlessCoefficientsCalculator(new ParametersCalculator(new TestCalculateOptions()));

        
        public void ConfigureCalculatorFor_FirstTest() // Consider a case when Vm > 2
        {
            _dimensionlessCoefficientsCalculator.Parameters.Options.SourceHeight = 180;
            _dimensionlessCoefficientsCalculator.Parameters.Options.OutcomeSpeed = 25;
            _dimensionlessCoefficientsCalculator.Parameters.Options.SourceMouthDiameter = 7;
            _dimensionlessCoefficientsCalculator.Parameters.Options.TemperatureDelta = 130;
        }

        public void ConfigureCalculatorFor_Vm_Greater_Than_Half_And_Less_Than_Or_Same_With_2_Case_Test()
        {
                
        }

        public void ConfigureCalculatorFor_Vm_Less_Than_Or_Same_With_Half_Case_Test()
        {

        }

        public void ConfigureCalculatorFor_F_Greater_Than_100() //Consider a case when VmHatch > 2
        {
            _dimensionlessCoefficientsCalculator.Parameters.Options.SourceHeight = 10;
        }

        public void ConfigureCalculatorFor_VmHatch_Greater_Than_Half_And_Less_Than_Or_Same_With_2_Case_Test()
        {
            
        }

        public void ConfigureCalculatorFor_VmHatch_Less_Than_Or_Same_With_Half_Case_Test()
        {
            
        }



        [TestMethod]
        public void CalculateDTest()
        {
            ConfigureCalculatorFor_FirstTest();
            Assert.IsTrue(Math.Abs(Math.Round(_dimensionlessCoefficientsCalculator.CalculateD(), 2) - 21.56) < Double.Epsilon);
        }

        [TestMethod]
        public void CalculateMTest()
        {
            ConfigureCalculatorFor_FirstTest();
            Assert.IsTrue(Math.Abs(Math.Round(_dimensionlessCoefficientsCalculator.CalculateM(), 2) - 0.70) < Double.Epsilon);
        }

        [TestMethod]

        public void CalculateNTest()
        {
            ConfigureCalculatorFor_FirstTest();
            Assert.IsTrue(Math.Abs(_dimensionlessCoefficientsCalculator.CalculateN() - 1) < Double.Epsilon);
        }
    }

}
