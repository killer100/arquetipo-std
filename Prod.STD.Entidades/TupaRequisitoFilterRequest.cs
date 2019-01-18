using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades
{
    public class TupaRequisitoFilterRequest : PagedRequest
    {
        
        public int id_tupa { get; set; }
    }
}
