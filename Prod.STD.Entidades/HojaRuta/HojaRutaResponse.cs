using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.HojaRuta
{
    public class HojaRutaResponse
    {
        public int? id_movimiento_documento { get; set; }
        public string oficina_origen { get; set; }
        public string oficina_destino { get; set; }
        public string documento { get; set; }
        public int? id_oficio { get; set; }
        public DateTime? fecha_registro { get; set; }
        public DateTime? fecha_recepcion { get; set; }
        public string derivado_por { get; set; }
        public string delegado_a { get; set; }
        public string acciones { get; set; }
        public string estado { get; set; }
        public string aceptado_por { get; set; }

        public string clase_documento { get; set; }
        public string indicativo { get; set; }
        public string asunto { get; set; }
        public string observaciones { get; set; }
        public string pendiente { get; set; }

    }
}
