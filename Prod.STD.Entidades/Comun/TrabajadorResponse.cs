using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun
{
    public class TrabajadorResponse
    {
        public int? codigo_trabajador { get; set; }
        public int? codigo_dependencia { get; set; }
        public string apellidos_trabajador { get; set; }
        public string nombres_trabajador { get; set; }
        public string condicion { get; set; }
        public string email { get; set; }
        public string fecha_nacimiento { get; set; }
        public string identificador { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string estado { get; set; }
        public int? audit_mod { get; set; }
        public DateTime? publicado { get; set; }
        public int? idprofesion { get; set; }
        public int? idsubdependencia { get; set; }
        public int? coddep_pub { get; set; }
        public string codigo_maestro { get; set; }
        public int? director { get; set; }
        public int? publicado_intranet { get; set; }

        public string nombre_format
        {
            get
            {
                return $"{apellidos_trabajador}, {nombres_trabajador}";
            }
        }

        public virtual DependenciaResponse dependencia { get; set; }
    }
}
