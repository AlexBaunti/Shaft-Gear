using System;
using NUnit.Framework;
using ShaftGearPlugin.Model;

namespace ShaftGearPlugin.UnitTests
{
    [TestFixture]
    public class ShaftGearParameterTest
    {
        [Test(Description = "Positive Getter Test.")]
        public void TestValueGet_CorrectValue()
        {
            var expected = 10;

            var shaftGearParameter = new ShaftGearParameter(10, 5, 20);
            var actual = shaftGearParameter.Value;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test(Description = "Negative Getter Test. Value Less Then MinValue.")]
        public void TestValueMinValueGet_IncorrectValue()
        {
            const double minValue = 30;
            const double maxValue = 50;
            const double value = 25;

            var actual = Assert.Throws<ArgumentOutOfRangeException>
                (() => new ShaftGearParameter(value, minValue, maxValue));
            var expected = $"Value Can Be Only Between {minValue} And {maxValue}";

            Assert.That(actual?.ParamName, Is.EqualTo(expected));
        }

        [Test(Description = "Negative Getter Test. Value Bigger Then MaxValue.")]
        public void TestValueMaxValueGet_IncorrectValue()
        {
            const double minValue = 30;
            const double maxValue = 50;
            const double value = 60;

            var actual = Assert.Throws<ArgumentOutOfRangeException>
                (() => new ShaftGearParameter(value, minValue, maxValue));
            var expected = $"Value Can Be Only Between {minValue} And {maxValue}";

            Assert.That(actual?.GetType(), Is.EqualTo(typeof(ArgumentOutOfRangeException)));
        }
    }
}