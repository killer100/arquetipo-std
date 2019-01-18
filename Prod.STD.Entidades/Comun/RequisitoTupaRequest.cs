using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun
{
    public class RequisitoTupaRequest
    {
        public int id_requisito { get; set; }
        public int? id_tupa { get; set; }
        public int? numero_requisito { get; set; }
        public string descripcion { get; set; }
        public int? estado { get; set; }
        public string id_tipo_requisito { get; set; }
        public decimal? valor_uit { get; set; }
        public decimal? monto { get; set; }

        public string descripcion_format { get; set; }
        public string observaciones { get; set; }
        public bool estado_observacion { get; set; }
    }
}
