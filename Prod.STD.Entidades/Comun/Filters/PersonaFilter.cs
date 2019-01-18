using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun.Filters
{
    public class PersonaFilter
    {
        /// <summary>
        /// filtra por campo: razon_social
        /// </summary>
        public string razon_social { get; set; }

        /// <summary>
        /// filtra por campo: nro_documento
        /// </summary>
        public string nro_documento { get; set; }
        /// <summary>
        /// filtra por campo: id_tipo_persona
        /// </summary>
        public int? id_tipo_persona { get; set; }

        /// <summary>
        /// cantidad a listar: default 100
        /// </summary>
        public int? limit { get; set; }
    }
}
