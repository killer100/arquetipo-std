using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades
{
    public class DetalleExpedienteFilterRequest : PagedRequest
    {
        public int id_documento { get; set; }
    }
}
