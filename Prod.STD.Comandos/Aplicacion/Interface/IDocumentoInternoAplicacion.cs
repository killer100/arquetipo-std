using Prod.STD.Entidades.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion.Interface
{
    public interface IDocumentoInternoAplicacion
    {
        DocumentoResponse Save(DocumentoRequest request);
    }
}
