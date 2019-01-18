//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum ESTADO_DE_DEPOSITO
    {
    NONE = 0,
        PENDIENTE = 17001,
        VALIDADO = 17002,
        AMORTIZADO = 17003,
        RECHAZADA = 17004,
        AUTOGENERADO = 17005,
        INVALIDADO = 17006,
    }
}
