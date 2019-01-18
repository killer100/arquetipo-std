using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.ContadorInterno
{
    public class ContadorInternoResponse
    {
        public int id { get; set; }
        public int id_documento { get; set; }
        public int contador { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public int estado { get; set; }
        public string usuario { get; set; }
        public string hoja_tramite { get
            {
                return $"{String.Format("{0:00000000}", this.contador)}-{this.fecha_registro.Year}";
            }
        }
    }
}
