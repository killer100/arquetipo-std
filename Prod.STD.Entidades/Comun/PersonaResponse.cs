using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Prod.STD.Entidades.Comun
{
    public class PersonaResponse
    {
        public int id { get; set; }
        public int id_tipo_persona { get; set; }
        public int id_tipo_identificacion { get; set; }
        public string razon_social { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nro_documento { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string representante_legal { get; set; }
        public string nro_documento_representante { get; set; }
        public int? id_tipo_identificacion_rep_leg { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }

        public string razon_social_format
        {
            get
            {
                return $"{razon_social} {nombres} {apellidos}".Trim();
            }

        }

        public string domicilio
        {
            get
            {
                var direc = Regex.Replace(direccion, @"\s+", " ");
                return $"{direc.Trim()} - {departamento} - {provincia} - {distrito}".Trim();
            }
        }
    }
}
