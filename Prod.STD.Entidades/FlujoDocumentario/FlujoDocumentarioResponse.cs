using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Correspondencia;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.FlujoTrabajador;
using Prod.STD.Entidades.HojaRuta;
using Prod.STD.Entidades.Resolucion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.FlujoDocumentario
{
    public class FlujoDocumentarioResponse
    {
        public DocumentoHojaTramiteResponse documento { get; set; }
        public ICollection<AnexoResponse> anexos { get; set; }
        public ICollection<HojaRutaResponse> flujoDependencias { get; set; }
        public ICollection<FlujoTrabajadorResponse> flujoTrabajadores { get; set; }
        public ICollection<CorrespondenciaResponse> correspondencias { get; set; }
        public ICollection<ResolucionResponse> resoluciones { get; set; }
        //public ICollection<AnexoResponse> documento { get; set; }
        //public ICollection<AnexoResponse> expedientesAcumulados { get; set; }




    }
}
