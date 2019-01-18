using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoAdjunto
{
    public class DocumentoAdjuntoRequest
    {
        public int id_documento_adjunto { get; set; }
        public string nombre_adjunto { get; set; }
        public string codigo { get; set; }
        public int id_documento { get; set; }
        public string mimetype { get; set; }
        public bool flag { get; set; }
        public  int? size { get; set; }
    }
}
