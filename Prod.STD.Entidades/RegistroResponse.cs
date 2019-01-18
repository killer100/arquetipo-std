using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades
{
    public class RegistroResponse : PagedRequest
    {
        public int id_registro { get; set; }
        public string codigo_tributo { get; set; }
        public string nom_codigo { get; set; }
        public string codigo_oficina { get; set; }
        public string nom_oficina { get; set; }
        public string direccion { get; set; }
        public string cajero { get; set; }
        public string nom_documento { get; set; }
        public string num_documento { get; set; }
        public string razsoc_nomape { get; set; }
        public string trama_registro { get; set; }
        public string nom_archivo { get; set; }
        public string num_registro { get; set; }
        public decimal importe { get; set; }
        public DateTime? fecha_pago { get; set; }
        public TimeSpan hora { get; set; }
        public string secuencia { get; set; }
        public string digito_chequeo { get; set; }
        public string filler { get; set; }
        public long TotalRows { get; set; }
        public string documento_concatenado {
            get { return nom_documento +" N° "+ num_documento; }
                }
    }
}
