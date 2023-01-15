using System;
using NUnit.Framework;
using ShaftGearPlugin.Model;

namespace ShaftGearPlugin.UnitTests
{
    [TestFixture]
    public class ShaftGearParametersTest
    {
        /// <summary>
        /// Параметры вал-шестерни.
        /// </summary>
        private readonly ShaftGearParameters _parameters = new ShaftGearParameters();

        [Test(Description = "Positive Setter Test. Dependent Parameter Values.")]
        public void TestSetDependentParameters_CorrectValues()
        {
            var expectedConnectorDiameter = _parameters.GetParameterValue(ShaftGearParametersType.ConnectorDiameter);
            var expectedBaseDiameter = _parameters.GetParameterValue(ShaftGearParametersType.BaseDiameter);
            var expectedTipDiameter = _parameters.GetParameterValue(ShaftGearParametersType.TipDiameter);
            var expectedTipLength = _parameters.GetParameterValue(ShaftGearParametersType.TipLength);

            _parameters.SetParameterValue(ShaftGearParametersType.ConnectorDiameter, expectedConnectorDiameter);
            _parameters.SetParameterValue(ShaftGearParametersType.BaseDiameter, expectedBaseDiameter);
            _parameters.SetParameterValue(ShaftGearParametersType.TipDiameter, expectedTipDiameter);
            _parameters.SetParameterValue(ShaftGearParametersType.TipLength, expectedTipLength);

            Assert.Multiple(() =>
            {
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.ConnectorDiameter),
                    Is.EqualTo(expectedConnectorDiameter));
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.BaseDiameter),
                    Is.EqualTo(expectedBaseDiameter));
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.TipDiameter),
                    Is.EqualTo(expectedTipDiameter));
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.TipLength),
                    Is.EqualTo(expectedTipLength));
            });
        }

        [Test(Description = "Positive Setter Test. Dependent Parameter Values.")]
        public void TestSetDefaultParameters_CorrectValues()
        {
            var expectedGearWidth = 145;
            var expectedGearDiameter = 95;

            _parameters.SetDefaultParameterValue(ShaftGearParametersType.GearWidth, expectedGearWidth);
            _parameters.SetDefaultParameterValue(ShaftGearParametersType.GearDiameter, expectedGearDiameter);

            Assert.Multiple(() =>
            {
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.GearWidth),
                    Is.EqualTo(expectedGearWidth));
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.GearDiameter),
                    Is.EqualTo(expectedGearDiameter));
            });
        }

        [Test(Description = "Negative Setter Test. Dependent Parameter Values.")]
        public void TestSetDependentParameter_IncorrectValues()
        {
            var actualConnectorDiameterException = Assert.Throws<ArgumentOutOfRangeException>(() =>
                _parameters.SetParameterValue(ShaftGearParametersType.ConnectorDiameter, 91));
            var actualBaseDiameterException = Assert.Throws<ArgumentOutOfRangeException>(() =>
                _parameters.SetParameterValue(ShaftGearParametersType.BaseDiameter, 94));
            var actualTipDiameterException = Assert.Throws<ArgumentOutOfRangeException>(() =>
                _parameters.SetParameterValue(ShaftGearParametersType.TipDiameter, 50));
            var actualTipLengthException = Assert.Throws<ArgumentOutOfRangeException>(() =>
                _parameters.SetParameterValue(ShaftGearParametersType.TipLength, 38));

            Assert.Multiple(() =>
            {
                Assert.That(actualConnectorDiameterException?.GetType(), 
                    Is.EqualTo(typeof(ArgumentOutOfRangeException)));
                Assert.That(actualBaseDiameterException?.GetType(), 
                    Is.EqualTo(typeof(ArgumentOutOfRangeException)));
                Assert.That(actualTipDiameterException?.GetType(), 
                    Is.EqualTo(typeof(ArgumentOutOfRangeException)));
                Assert.That(actualTipLengthException?.GetType(), 
                    Is.EqualTo(typeof(ArgumentOutOfRangeException)));
            });
        }
    }
}