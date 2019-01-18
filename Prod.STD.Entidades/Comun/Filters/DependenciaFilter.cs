using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun.Filters
{
    public class DependenciaFilter
    {
        /// <summary>
        /// Si es true, obtiene todos las dependencias activas.
        /// Default: true
        /// </summary>
        public bool activo { get; set; } = true;

        /// <summary>
        /// Si es true, se filtran los ID_TIPO_DEPENDENCIA 2 y 5.
        /// Default: false
        /// </summary>
        public bool dependencias_internas { get; set; } = false;
    }
}
