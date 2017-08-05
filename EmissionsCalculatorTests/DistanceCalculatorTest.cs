using System;
using EmissionsCalculator.Calculators;
using EmissionsCalculator.CalculatorTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EmissionsCalculatorTests
{
    [TestClass]
    public class DistanceCalculatorTest
    {
        public IDistanceCalculator Calculator;

        

        [TestMethod]
        public void Test()
        {
            Assert.IsNotNull(Calculator);
        }

    }
}