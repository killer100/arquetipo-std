//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum TIPO_DE_SANCION
    {
    NONE = 0,
        MULTA = 38001,
        DECOMISO = 38002,
        SUSPENCION_DE_PERMISO_DE_PESCA = 38003,
        SUSPENCION_DE_LICENCIA_DE_OPERACION = 38004,
        CANCELACION_DE_PERMISO_DE_PESCA = 38005,
        CANCELACION_DE_LICENCIA_DE_OPERACION = 38006,
        REDUCCION = 38007,
    }
}
