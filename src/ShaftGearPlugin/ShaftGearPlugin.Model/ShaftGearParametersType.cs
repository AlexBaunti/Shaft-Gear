using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaftGearPlugin.Model
{
    /// <summary>
    /// Список параметров вал-шестерни
    /// </summary>
    public enum ShaftGearParametersType
    {
        /// <summary>
        /// Ширина шестерни
        /// </summary>
        GearWidth,

        /// <summary>
        /// Диаметер шестерни
        /// </summary>
        GearDiameter,

        /// <summary>
        /// Диаметер соединителя
        /// </summary>
        ConnectorDiameter,

        /// <summary>
        /// Диаметр основания вала
        /// </summary>
        BaseDiameter,

        /// <summary>
        /// Диаметр вращательного цилиндра вала
        /// </summary>
        TipDiameter,

        /// <summary>
        /// Длина вращательного цилиндра вала
        /// </summary>
        TipLength
    }
}
