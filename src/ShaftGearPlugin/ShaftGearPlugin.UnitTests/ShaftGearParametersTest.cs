using System;
using NUnit.Framework;
using ShaftGearPlugin.Model;

namespace ShaftGearPlugin.UnitTests
{
    class ShaftGearParametersTest
    {
        /// <summary>
        /// ShaftGear parameters.
        /// </summary>
        private readonly ShaftGearParameters _parameters = new ShaftGearParameters();

        [Test(Description = "Positive Setter Test. Dependent Parameter Values.")]
        public void TestSetDependentParameters_CorrectValues()
        {
            var expectedConnectorDiameter = _parameters.GetParameterValue(ShaftGearParametersType.ConnectorDiameter);
            var expectedBaseDiameter = _parameters.GetParameterValue(ShaftGearParametersType.BaseDiameter);
            var expectedTipLength = _parameters.GetParameterValue(ShaftGearParametersType.TipLength);
            var expectedTipDiameter = _parameters.GetParameterValue(ShaftGearParametersType.TipDiameter);

            _parameters.SetParameterValue(ShaftGearParametersType.ConnectorDiameter, expectedConnectorDiameter);
            _parameters.SetParameterValue(ShaftGearParametersType.BaseDiameter, expectedBaseDiameter);
            _parameters.SetParameterValue(ShaftGearParametersType.TipLength, expectedTipLength);
            _parameters.SetParameterValue(ShaftGearParametersType.TipDiameter, expectedTipDiameter);

            Assert.Multiple(() =>
            {
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.ConnectorDiameter),
                    Is.EqualTo(expectedConnectorDiameter));
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.BaseDiameter),
                    Is.EqualTo(expectedBaseDiameter));
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.TipLength),
                    Is.EqualTo(expectedTipLength));
                Assert.That(_parameters.GetParameterValue(ShaftGearParametersType.TipDiameter),
                    Is.EqualTo(expectedTipDiameter));
            });
        }
    }
}
