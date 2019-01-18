using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.HojaRuta;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DetalleHojaRuta
{
    public class DetalleHojaRutaResponse
    {
        public DocumentoHojaTramiteResponse documento { get; set; }

        public ICollection<HojaRutaResponse> rutas { get; set; }
    }
}
