using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades
{
    public class TupaFilterRequest : PagedRequest
    {
        public string codigo_tributo { get; set; }            
    }
}
