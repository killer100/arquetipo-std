using Prod.STD.Datos.NoSQL.Modelo;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Base;

namespace Prod.STD.Datos.NoSQL.Repositorios
{
    public class TipoRepositorio : CustomBaseRepository<Tipo>, ITipoRepositorio
    {
        public TipoRepositorio(IDataContext context) : base(context)
        {
        }
    }
}
