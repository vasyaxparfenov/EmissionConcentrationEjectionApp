using System;
using EmissionsCalculator.CalculatorTypes;
using Moq;
using NUnit.Framework;

namespace EmissionsCalculator.Tests
{
    public abstract class CalculatorTests
    {
        public Mock<IParametersOptions> ParametersOptionsStub { get; set; }

        public virtual void ConfigureMockParametersOptions(double outcomeSpeed, double sourceHeight, double sourceMouthHeight,
            double temperatureDelta)
        {
            ParametersOptionsStub.SetupProperty(o => o.SourceHeight, sourceHeight);
            ParametersOptionsStub.SetupProperty(o => o.OutcomeSpeed, outcomeSpeed);
            ParametersOptionsStub.SetupProperty(o => o.TemperatureDelta, temperatureDelta);
            ParametersOptionsStub.SetupProperty(o => o.SourceMouthDiameter, sourceMouthHeight);
        }

        public virtual void GeneralAssert(double expectedResult, double result, int round)
        {
            Assert.IsTrue(Math.Abs(Math.Round(result, round) - expectedResult) < Double.Epsilon);
        }
    }
}