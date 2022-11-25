using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftGearPlugin.Model
{
    class ShaftGearParameter
    {
        /// <summary>
        /// Значение параметра.
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимальное допустимое значение.
        /// </summary>
        private readonly double _minValue;

        /// <summary>
        /// Максимальное допустимое значение.
        /// </summary>
        private readonly double _maxValue;

        /// <summary>
        /// Устанавливает и возвращает значение установленного парамера.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (IsRangeOut(value))
                {
                    throw new ArgumentException($"Value Can Be Only Between {_minValue} And {_maxValue}");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Сборка класса параметра.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="minValue">Минимально допустимое значение.</param>
        /// <param name="maxValue">Максимально допустимое значение.</param>
        public ShaftGearParameter(double value, double minValue, double maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            Value = value;
        }

        /// <summary>
        /// Проверяет допустимость значения параметра.
        /// </summary>
        /// <param name="value">Значение параметра</param>
        /// <returns></returns>
        private bool IsRangeOut(double value)
        {
            return value < _minValue || value > _maxValue;
        }
    }
}
