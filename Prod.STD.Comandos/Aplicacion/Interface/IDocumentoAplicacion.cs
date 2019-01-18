using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion.Interface
{
    public interface IDocumentoAplicacion
    {
        void Anular(DocumentoRequest request);
        void Reactivar(DocumentoRequest request);
        void AgregarCopias(DocumentoRequest request);
        void LevantarObservaciones(DocumentoRequest request);
        string GenerarReporteDocumentosIngresados(ReporteDocumentosIngresadosRequest request);
        void RevertirDocumentoReporteIngresado(DocumentoIngresadoRequest request);
        string GenerarReporteDocumentosEscaneados(ReporteDocumentosEscaneadosRequest request);
        void RevertirDocumentoReporteEscaneado(DocumentoEscaneadoRequest request);
    }
}
