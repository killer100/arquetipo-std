using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Prod.STD.Entidades
{
    public class Persona
    {
        public int id_persona { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }

        //[Required(ErrorMessage = "El dni es requerido papá")]
        public string dni { get; set; }
        public int id_genero { get; set; }
        public Nullable<System.DateTime> fecha_nacimiento { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }

        
    }
}
