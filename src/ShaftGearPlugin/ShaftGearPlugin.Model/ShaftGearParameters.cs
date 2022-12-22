using System;
using System.Collections.Generic;

namespace ShaftGearPlugin.Model
{
    public class ShaftGearParameters
    {
        /// <summary>
        /// Типы параметров и их значения.
        /// </summary>
        private readonly Dictionary<ShaftGearParametersType, ShaftGearParameter> _parameters;

        /// <summary>
        /// Определение параметров вал-шестерни.
        /// </summary>
        public ShaftGearParameters()
        {
            _parameters = new Dictionary<ShaftGearParametersType, ShaftGearParameter>()
            {
                { ShaftGearParametersType.GearWidth, new ShaftGearParameter(145, 70, 200) },
                { ShaftGearParametersType.GearDiameter, new ShaftGearParameter(95, 70, 120) },
                { ShaftGearParametersType.ConnectorDiameter, new ShaftGearParameter(95, 85, 105) },
                { ShaftGearParametersType.BaseDiameter, new ShaftGearParameter(90, 80, 100) },
                { ShaftGearParametersType.TipDiameter, new ShaftGearParameter(38, 20, 55) },
                { ShaftGearParametersType.TipLength, new ShaftGearParameter(50, 30, 75) },
            };
        }

        /// <summary>
        /// Устанавливает значение параметра.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetParameterValue(ShaftGearParametersType type, double value)
        {
            CheckDependencies(type, value);
            _parameters[type].Value = value;
        }

        /// <summary>
        /// Устанавливает значение параметра по умолчанию.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public void SetDefaultParameterValue(ShaftGearParametersType type, double value)
        {
            _parameters[type].Value = value;
        }

        /// <summary>
        /// Получает значения параметров.
        /// </summary>
        /// <param name="type">Тип параметра</param>
        /// <returns>Значение параметра</returns>
        public double GetParameterValue(ShaftGearParametersType type)
        {
                return _parameters[type].Value;
        }

        /// <summary>
        /// Проверка зависимых параметров.
        /// </summary>
        /// <param name="type">Тип параметра</param>
        /// <param name="value">Значение параметра</param>
        /// <exception cref="Exception">Если значение параметра некорректное.</exception>
        private void CheckDependencies(ShaftGearParametersType type, double value)
        {
            switch (type)
            {
                case ShaftGearParametersType.ConnectorDiameter:
                {
                    _parameters.TryGetValue(ShaftGearParametersType.BaseDiameter, out var parameter);
                    if (value - parameter.Value < 5)
                    {
                        throw new ArgumentOutOfRangeException("Connector Diameter Must Be at Least 5mm More Base Diameter");
                    }
                    break;
                }
                case ShaftGearParametersType.BaseDiameter:
                {
                    _parameters.TryGetValue(ShaftGearParametersType.ConnectorDiameter, out var parameter);
                    if (parameter.Value - value < 5)
                    {
                        throw new ArgumentOutOfRangeException("Base Diameter Must Be at Least 5mm Less Connector Diameter");
                    }
                    break;
                }
                case ShaftGearParametersType.TipDiameter:
                {
                    _parameters.TryGetValue(ShaftGearParametersType.TipLength, out var parameter);
                    if (parameter.Value - value < 10)
                    {
                        throw new ArgumentOutOfRangeException("Tip Diameter Must Be at Least 10mm Less Tip Length");
                    }
                    break;
                }
                case ShaftGearParametersType.TipLength:
                {
                    _parameters.TryGetValue(ShaftGearParametersType.TipDiameter, out var parameter);
                    if (value - parameter.Value < 10)
                    {
                        throw new ArgumentOutOfRangeException("Tip Length Must Be at Least 10mm More Tip Diameter");
                    }
                    break;
                }
                default:
                {
                        return;
                }
            }
        }
    }
}