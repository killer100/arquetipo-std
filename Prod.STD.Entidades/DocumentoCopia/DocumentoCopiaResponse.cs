using Prod.STD.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoCopia
{
    public class DocumentoCopiaResponse
    {
        public int id_documento_copia { get; set; }
        public int id_documento { get; set; }
        public int coddep { get; set; }
        public DependenciaResponse dependencia { get; set; }
        public int estado { get; set; }
    }
}
