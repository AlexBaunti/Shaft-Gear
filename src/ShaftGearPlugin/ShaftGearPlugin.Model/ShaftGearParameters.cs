using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftGearPlugin.Model
{
    public class ShaftGearParameters
    {
        /// <summary>
        /// Типы параметров и их значения
        /// </summary>
        private readonly Dictionary<ShaftGearParametersType, ShaftGearParameter> _parameters;

        /// <summary>
        /// Параметры вал-шестерни
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
            parameter.Value = value;
        }
    }
}
