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
        /// Возвращает значение установленного парамера.
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (IsRangeOut(value))
                {
                    ///throw new ArgumentException($"Value Can Be Only Between {_minValue} And {_maxValue}");
                }
                _value = value;
            }
        }

        /// <summary>
        /// Получает минимальное допустимое значение.
        /// </summary>
        private readonly double _minValue;

        /// <summary>
        /// Получает максимальное допустимое значение.
        /// </summary>
        private readonly double _maxValue;

        /// <summary>
        /// Сборка класса.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        /// <param name="minValue">Минимально допустимое значение.</param>
        /// <param name="maxValue">Максимально допустимое значение.</param>
        public ShaftGearParameter(double minValue, double value, double maxValue)
        {
            Value = value;
            _minValue = minValue;
            _maxValue = maxValue;
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
