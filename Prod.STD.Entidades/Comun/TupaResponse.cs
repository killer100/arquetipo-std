using Prod.STD.Entidades.Enumerable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Prod.STD.Entidades.Comun
{
    public class TupaResponse
    {
        public int? id_tupa { get; set; }
        public int? id_clase_tupa { get; set; }
        public int? codigo_dependencia { get; set; }
        public string descripcion { get; set; }
        public int? numero_dias { get; set; }
        public decimal? uit { get; set; }
        public int? estado_tupa { get; set; }
        public int? tipo_aprobacion { get; set; }
        public int? numero_tupa { get; set; }
        public int? flag_cambio { get; set; }
        public int? id_sector { get; set; }
        public int? id_tipo_silencio { get; set; }
        public string dependencia { get; set; }
        public string siglas { get; set; }
        public string descripcion_format
        {
            get
            {
                return string.IsNullOrEmpty(descripcion) ? "" : Regex.Replace(descripcion, "<.*?>", String.Empty);
            }
        }
    }
}
