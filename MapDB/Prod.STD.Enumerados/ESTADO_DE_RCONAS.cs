//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum ESTADO_DE_RCONAS
    {
    NONE = 0,
        PENDIENTE = 32001,
        PREEVALUADO = 32002,
        REGISTRADO = 32003,
        EN_ATENCION = 32004,
        ATENDIDO = 32005,
        INADMISIBLE = 32006,
        OBSERVADO = 32007,
        POR_SESIONAR = 32008,
        PRONUNCIADO = 32009,
        POR_RENOTIFICAR = 32010,
        RENOTIFICADO = 32011,
    }
}
