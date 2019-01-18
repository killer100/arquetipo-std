using Release.Helper.Pagination;

namespace Prod.STD.Entidades
{
    public class PersonaFilter : PagedRequest
    {
        public int id_persona { get; set; }
        public string dni { get; set; }

        public string query { get; set; }
    }
}
