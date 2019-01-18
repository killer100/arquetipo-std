//===================================================================================
// Template T4 for Enum
//===================================================================================
using System;

namespace Prod.STD.Enumerados
{
   
    //[Serializable]
    public enum ESTADO_DE_EXPEDIENTE_PAS
    {
    NONE = 0,
        FISCALIZACION = 13001,
        SANCION = 13002,
        APELACION = 13003,
        COACTIVA = 13004,
        SANCION_CON_RESOLUCION = 13005,
        ARCHIVADO = 13006,
        SUPERVISION = 13007,
        CANCELADO = 13008,
        SUSPENDIDO = 13009,
    }
}
