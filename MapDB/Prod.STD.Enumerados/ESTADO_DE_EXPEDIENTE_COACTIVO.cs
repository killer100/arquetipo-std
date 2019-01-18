//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum ESTADO_DE_EXPEDIENTE_COACTIVO
    {
    NONE = 0,
        REGISTRADO = 16001,
        PENDIENTE = 16002,
        CANCELADO = 16003,
        ARCHIVADO = 16004,
        SUSPENDIDO = 16005,
        NO_INICIO = 16006,
        INICIO = 16007,
        COBRANZA = 16008,
    }
}
