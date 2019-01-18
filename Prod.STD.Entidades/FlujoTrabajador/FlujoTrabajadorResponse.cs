using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.FlujoTrabajador
{
    public class FlujoTrabajadorResponse
    {
        public string siglas { get; set; }
        public string apellidos_trabajador { get; set; }
        public string nombre_trabajador { get; set; }
        public DateTime? audit_trab_der { get; set; }
        public DateTime? audit_trab_rec { get; set; }
        public string descripcion { get; set; }
        public string indicativo_oficio { get; set; }

        public string nombre_trabajador_format {
            get {
                return $"{apellidos_trabajador}, {nombre_trabajador}";
            }
        }
    }
}
