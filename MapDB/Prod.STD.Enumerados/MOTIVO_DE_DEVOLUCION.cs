//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum MOTIVO_DE_DEVOLUCION
    {
    NONE = 0,
        DEVOLUCION_DE_MULTAS_SANCIONES = 51001,
        DEVOLUCION_POR_SALDO_COACTIVA = 51002,
        DEVOLUCION_DE_PRONTO_PAGO = 51003,
        DEVOLUCION_POR_DECOMISO = 51004,
    }
}
