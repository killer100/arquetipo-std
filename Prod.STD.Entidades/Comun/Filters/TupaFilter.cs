using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun.Filters
{
    public class TupaFilter
    {
        /// <summary>
        /// default: 1
        /// <para></para>
        /// </summary>
        public int? estado { get; set; } = 1;
        public int? id_clase_tupa { get; set; }
    }
}
