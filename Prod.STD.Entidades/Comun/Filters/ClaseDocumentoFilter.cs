using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun.Filters
{
    public class ClaseDocumentoFilter
    {
        /// <summary>
        /// <para>"d": generado por dependencias.</para>
        /// <para>"t": generado por trabajadores.</para>
        /// </summary>
        public string categoria { get; set; }

        /// <summary>
        /// <para>"i": para documentos internos.</para>
        /// <para>"e": para documentos externos.</para>
        /// </summary>
        public string procedencia { get; set; }        
    }
}
