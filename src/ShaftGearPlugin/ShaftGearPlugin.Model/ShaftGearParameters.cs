﻿using System;
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
                { ShaftGearParametersType.ConnectorDiameter, new ShaftGearParameter(97, 85, 110) },
                { ShaftGearParametersType.BaseDiameter, new ShaftGearParameter(92, 80, 105) },
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
            if (!_parameters.TryGetValue(type, out var parameter)) return;
            CheckDependencies(type, value);
            parameter.Value = value;
        }

        /// <summary>
        /// Получает значения параметров.
        /// </summary>
        /// <param name="type">Тип параметра</param>
        /// <returns>Значение параметра</returns>
        /// <exception cref="Exception">Если параметр не задан</exception>
        public double GetParameterValue(ShaftGearParametersType type)
        {
            if (_parameters.TryGetValue(type, out var parameter))
            {
                return parameter.Value;
            }
            throw new ArgumentException("Parameter Does Not Exist");
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
                case ShaftGearParametersType.BaseDiameter:
                    {
                        _parameters.TryGetValue(ShaftGearParametersType.ConnectorDiameter, out var parameter);
                        if (parameter.Value - value < 5)
                        {
                            throw new ArgumentException("Connector Diameter Must Be at Least 5mm More Base Diameter");
                        }
                        break;
                    }
                case ShaftGearParametersType.TipLength:
                    {
                        _parameters.TryGetValue(ShaftGearParametersType.TipDiameter, out var parameter);
                        if (value - parameter.Value < 10)
                        {
                            throw new ArgumentException("Tip Length Must Be at Least 10mm More Tip Diameter");
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

