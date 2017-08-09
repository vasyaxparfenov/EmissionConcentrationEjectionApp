using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmissionsCalculator.Calculators;
using EmissionsCalculator.CalculatorTypes;
using Moq;
using NUnit.Framework;

namespace EmissionsCalculator.Tests
{
    public class ParametersCalculatorTests : CalculatorTests
    {
        public IParametersCalculator ParametersCalculator { get; set; }

        [SetUp]
        public void Setup()
        {
            ParametersOptionsStub = new Mock<IParametersOptions>(MockBehavior.Default);
            ParametersCalculator = new ParametersCalculator(ParametersOptionsStub.Object);
        }

        [TearDown]
        public void TearDown()
        {
            ParametersOptionsStub = null;
            ParametersCalculator = null;
        }
        
        [TestCase(1615.16, 25, 180, 7, 130)]
        public void CalculateFeTest_Calculating_ReturnsResultEqualToExpectedOne(double expectedResult, double outcomeSpeed, double sourceHeight, double sourceMouthHeight,
            double temperatureDelta)
        {
            ConfigureMockParametersOptions(outcomeSpeed, sourceHeight, sourceMouthHeight, temperatureDelta);
            var result = ParametersCalculator.CalculateFe();
            GeneralAssert(expectedResult, result, 2);
        }

        [TestCase(1.04, 25, 180, 7, 130)]
        public void CalculateFTest_Calculating_ReturnsResultEqualToExpectedOne(double expectedResult, double outcomeSpeed,
            double sourceHeight, double sourceMouthHeight,
            double temperatureDelta)
        {
            ConfigureMockParametersOptions(outcomeSpeed, sourceHeight, sourceMouthHeight, temperatureDelta);
            var result = ParametersCalculator.CalculateF();
            GeneralAssert(expectedResult, result, 2);
        }

        [TestCase(5.76, 25, 180, 7, 130)]
        public void CalculateVmTest_Calculating_ReturnsResultEqualToExpectedOne(double expectedResult, double outcomeSpeed,
            double sourceHeight, double sourceMouthHeight,
            double temperatureDelta)
        {
            ConfigureMockParametersOptions(outcomeSpeed, sourceHeight, sourceMouthHeight, temperatureDelta);
            var result = ParametersCalculator.CalculateVm();
            GeneralAssert(expectedResult, result, 2);
        }

        [TestCase(1.26, 25, 180, 7, 130)]
        public void CalculateVmHatchTest_Calculating_ReturnsResultEqualToExpectedOne(double expectedResult, double outcomeSpeed,
            double sourceHeight, double sourceMouthHeight,
            double temperatureDelta)
        {
            ConfigureMockParametersOptions(outcomeSpeed, sourceHeight, sourceMouthHeight, temperatureDelta);
            var result = ParametersCalculator.CalculateVmHatch();
            GeneralAssert(expectedResult, result, 2);
        }
        
    }
}
