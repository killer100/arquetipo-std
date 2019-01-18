using Release.Helper.Pagination;

namespace Prod.STD.Entidades
{
    public class RegistroFilterRequest : PagedRequest
    {
        public string filtro  { get; set; }
        public int id_registro { get; set; }      
    }
}
