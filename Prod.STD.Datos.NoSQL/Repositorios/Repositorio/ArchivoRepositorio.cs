using MongoDB.Driver;
using Prod.STD.Datos.NoSQL.Modelo;
using Release.MongoDB.Repository;
using Release.MongoDB.Repository.Base;

namespace Prod.STD.Datos.NoSQL.Repositorios
{
    public class ArchivoRepositorio : CustomBaseRepository<Archivo>, IArchivoRepositorio
    {
        public ArchivoRepositorio(IDataContext context) : base(context)
        {
        }       
    }
}
