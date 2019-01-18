using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Documento
{

    public class DocumentoOptions
    {
        public bool withEstado { get; set; } = false;

        public bool withPersona { get; set; } = false;

        public bool withMovimientos { get; set; } = false;

        public bool withClaseDocumento { get; set; } = false;

        public bool withRequisitos { get; set; } = false;

        public bool withTupa { get; set; } = false;

        public bool withAnexos { get; set; } = false;

        public bool withHojaTramite { get; set; } = false;

        public bool withCopias { get; set; } = false;

    }


}
