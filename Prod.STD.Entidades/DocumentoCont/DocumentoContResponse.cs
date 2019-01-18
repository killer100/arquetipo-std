using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoCont
{
    public class DocumentoContResponse
    {
        public int id_documento { get; set; }
        public int cant_copias { get; set; }
        public int cant_adjuntos { get; set; }
    }
}
