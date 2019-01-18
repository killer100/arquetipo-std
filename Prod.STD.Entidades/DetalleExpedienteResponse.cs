using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades
{
    public class DetalleExpedienteResponse
    {
        public int id_movimiento_documento { get; set; }
        public int id_documento { get; set; }
        public string numero_expediente { get; set; }
        public string documento_interno { get; set; }
        public string fecha_registro { get; set; }
        public string asunto { get; set; }
        public  string dependencia_origen { get; set; }
        public string dependencia_destino { get; set; }
       

    }
}
