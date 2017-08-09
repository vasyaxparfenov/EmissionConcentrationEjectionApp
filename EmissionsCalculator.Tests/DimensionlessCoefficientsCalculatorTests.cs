using System;
using EmissionsCalculator.Calculators;
using EmissionsCalculator.CalculatorTypes;
using Moq;
using NUnit.Framework;

namespace EmissionsCalculator.Tests
{
    public class DimensionlessCoefficientsCalculatorTests : CalculatorTests
    {
        public IDimensionlessCoefficientsCalculator DimensionlessCoefficientsCalculator { get; set; }
        
        public Mock<IParametersCalculator> ParametersCalculatorMock { get; set; }
        

        [SetUp]
        public void Setup()
        {
            ParametersOptionsStub = new Mock<IParametersOptions>(MockBehavior.Default);
            ParametersCalculatorMock = new Mock<IParametersCalculator>(MockBehavior.Default);
            DimensionlessCoefficientsCalculator = new DimensionlessCoefficientsCalculator(ParametersCalculatorMock.Object);
            ((IParameterised) DimensionlessCoefficientsCalculator).Options = ParametersOptionsStub.Object;
        }

        [TearDown]
        public void TearDown()
        {
            ParametersOptionsStub = null;
            DimensionlessCoefficientsCalculator = null;
            ParametersCalculatorMock = null;
        }

        [TestCase()]
        public void CalculateMTest_FLesserThan100_ReturnsResultEqualToExpectedOne(double expectedResult, double f)
        {
            if(f >= 100) { throw new ArgumentException("F should be lesser than 100");}
            ParametersCalculatorMock.Setup(p => p.CalculateF()).Returns(f);
            var result = DimensionlessCoefficientsCalculator.CalculateM();
            GeneralAssert(expectedResult, result, 2);
        }
        [TestCase()]
        public void CalculateMTest_FGreaterThan100_ReturnsResultEqualToExpectedOne(double expectedResult, double f)
        {
            if(f < 100) { throw new ArgumentException("F should be greater than 100"); }
            ParametersCalculatorMock.Setup(p => p.CalculateF()).Returns(f);
            var result = DimensionlessCoefficientsCalculator.CalculateM();
            GeneralAssert(expectedResult, result, 2);
        }



    }
}