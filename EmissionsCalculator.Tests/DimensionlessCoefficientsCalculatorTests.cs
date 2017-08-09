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

        public void ConfigureParametersCalculator(double f, double vm = 0, double vmHatch = 0)
        {
            ParametersCalculatorMock.Setup(p => p.CalculateF()).Returns(f);
            ParametersCalculatorMock.Setup(p => p.CalculateVm()).Returns(vm);
            ParametersCalculatorMock.Setup(p => p.CalculateVmHatch()).Returns(vmHatch);
        }

        [Test]
        public void CalculateMTest_Calculating_IParameteresCalculatorCalculateFIsCalled()
        {
            DimensionlessCoefficientsCalculator.CalculateM();
            ParametersCalculatorMock.Verify(p => p.CalculateF());
        }

        [TestCase()]
        public void CalculateMTest_Calculating_ReturnsResultEqualToExpectedOne(double expectedResult, double f, int round)
        {

            ConfigureParametersCalculator(f);
            var result = DimensionlessCoefficientsCalculator.CalculateM();
            GeneralAssert(expectedResult, result, round);
        }
        
        [Test]
        public void CalculateDTest__Calculating_IParametersCalculatorCalculateFIsCalled()
        {
            DimensionlessCoefficientsCalculator.CalculateD();
            ParametersCalculatorMock.Verify(p => p.CalculateF());
        }

        [Test]
        public void CalculateDTest__Calculating_IParametersCalculatorCalculateVmIsCalled()
        {
            DimensionlessCoefficientsCalculator.CalculateD();
            ParametersCalculatorMock.Verify(p => p.CalculateVm());
        }

        [Test]
        public void CalculateDTest_FGreaterThan100_IParametersCalculatorCalculateVmHatchIsCalled()
        {
            ConfigureParametersCalculator(101);
            DimensionlessCoefficientsCalculator.CalculateD();
            ParametersCalculatorMock.Verify(p => p.CalculateVm());
        }

        [TestCase()]
        public void CalculateDTest_Calculating_ReturnsResultEqualToExpectedOne(double expectedResult, double f, double vm, double vmHatch, int round)
        {
            ConfigureParametersCalculator(f, vm, vmHatch);
            var result = DimensionlessCoefficientsCalculator.CalculateD();
            GeneralAssert(expectedResult, result, round);
        }
        
        [Test]
        public void CalculateNTest_Calculating_IParametersCalculatorCalculateVmIsCalled()
        {
            DimensionlessCoefficientsCalculator.CalculateN();
            ParametersCalculatorMock.Verify(p => p.CalculateVm());
        }

        [TestCase()]
        public void CalculateNTest_Calculating_ReturnsResultEqualToExpectedOne(double expectedResult, double vm, int round)
        {
            ConfigureParametersCalculator(0, vm);
            var result = DimensionlessCoefficientsCalculator.CalculateN();
            GeneralAssert(expectedResult, result, round);
        }

        [Test]
        public void CalculateFTest_FilterCoefficientsGreaterThanOrEqual90_Returns2()
        {
            ParametersOptionsStub.SetupProperty(o => o.FilterCoefficient, 90);
            var result = DimensionlessCoefficientsCalculator.CalculateF();
            GeneralAssert(2, result, 0);
        }

        [Test]
        public void CalculateFTest_FilterCoefficientsLesserThan90AndGreaterThanOrEqual75_Returns2andHalf()
        {
            ParametersOptionsStub.SetupProperty(o => o.FilterCoefficient, 75);
            var result = DimensionlessCoefficientsCalculator.CalculateF();
            GeneralAssert(2.5, result, 1);
        }

       
    }
}