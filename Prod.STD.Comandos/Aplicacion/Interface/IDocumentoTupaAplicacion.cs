using Prod.STD.Entidades.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion.Interface
{
    public interface IDocumentoTupaAplicacion
    {
        DocumentoResponse Save(DocumentoRequest request);
        void Update(int id_documento, DocumentoRequest request);
    }
}
