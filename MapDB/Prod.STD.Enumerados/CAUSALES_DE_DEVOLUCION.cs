//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum CAUSALES_DE_DEVOLUCION
    {
    NONE = 0,
        ERROR_EN_CONSTANCIA_DE_EXIGIBILIDAD = 23001,
        ERROR_EN_NOTIFICACION_DE_CEDULA_PERSONAL_DE_LA_RESOLUCION_SANCIONADORA = 23002,
        ERROR_EN_RESOLUCION_SANCIONADORA = 23003,
        ERROR_EN_RESOLCUION_DE_SEGUNDA_INSTANCIA_CONAS = 23004,
        ERROR_EN_NOTIFICACION_DE_CEDULA_PERSONAL_DE_LA_RESOLUCIONES_DE_SEGUNDA_INSTANCIA_CONAS = 23005,
        POR_TITULO_DE_EJECUCION_CANCELADO = 23006,
        POR_TITULO_DE_EJECUCION_JUDICIALIZADO = 23007,
    }
}
