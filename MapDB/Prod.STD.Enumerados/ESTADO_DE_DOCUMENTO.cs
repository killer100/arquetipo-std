//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum ESTADO_DE_DOCUMENTO
    {
    NONE = 0,
        ELABORADO = 12001,
        OBSERVADO = 12002,
        APROBADO = 12003,
        APROBADO_PARA_ATENCION = 12004,
        DENEGADO = 12005,
        PENDIENTE_DE_FIRMA = 12006,
        FIRMADO = 12007,
        NOTIFICADO_FISICA = 12008,
        NOTIFICADO_ELECTRONICAMENTE = 12009,
        ADJUNTADO = 12010,
        PENDIENTE_DE_NOTIFICACION = 12011,
        RECEPCIONADO = 12012,
        DERIVADO = 12013,
        ELABORANDOSE = 12014,
        REGISTRANDOSE = 12015,
        ADJUNTANDOSE = 12016,
        NO_NOTIFICADO = 12017,
        GENERADO = 12018,
        ATENDIDO = 12019,
    }
}
