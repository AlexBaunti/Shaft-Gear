using System;
using System.Collections.Generic;

namespace ShaftGearPlugin.Model
{
    public class ShaftGearParameters
    {
        /// <summary>
        /// Типы параметров и их значения
        /// </summary>
        private readonly Dictionary<ShaftGearParametersType, ShaftGearParameter> _parameters;

        /// <summary>
        /// Определение параметров вал-шестерни
        /// </summary>
        public ShaftGearParameters()
        {
            _parameters = new Dictionary<ShaftGearParametersType, ShaftGearParameter>()
            {
                { ShaftGearParametersType.GearWidth, new ShaftGearParameter(70, 145, 200) },
                { ShaftGearParametersType.GearDiameter, new ShaftGearParameter(70, 95, 120) },
                { ShaftGearParametersType.ConnectorDiameter, new ShaftGearParameter(85, 97, 110) },
                { ShaftGearParametersType.BaseDiameter, new ShaftGearParameter(80, 92, 105) },
                { ShaftGearParametersType.TipDiameter, new ShaftGearParameter(10, 32, 55) },
                { ShaftGearParametersType.TipLength, new ShaftGearParameter(5, 40, 75) },
            };
        }

        /// <summary>
        /// Устанавливает значение параметра
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
            throw new Exception("Parameter Does Not Exist");
        }

        /// <summary>
        /// Проверка зависимых параметров.
        /// </summary>
        /// <param name="type">Тип параметра</param>
        /// <param name="value">Значение параметра</param>
        /// <exception cref="Exception">If the parameter values ​​are set incorrectly.</exception>
        private void CheckDependencies(ShaftGearParametersType type, double value)
        {
            switch (type)
            {
                case ShaftGearParametersType.ConnectorDiameter:
                    {
                        _parameters.TryGetValue(ShaftGearParametersType.BaseDiameter, out var parameter);
                        if (parameter.Value - value < 5)
                        {
                            throw new Exception("Connector Diameter Must Be at List 5 Units More Base Diameter");
                        }
                        break;
                    }
                case ShaftGearParametersType.TipLength:
                    {
                        _parameters.TryGetValue(ShaftGearParametersType.TipDiameter, out var parameter);
                        if (parameter.Value - value < 10)
                        {
                            throw new Exception("Tip Length Must Be at Least 10 Units More Tip Diameter");
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

