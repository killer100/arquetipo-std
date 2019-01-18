using System;
using MongoDB.Bson;

namespace Prod.STD.Datos.NoSQL.Modelo
{
    public interface IEntity<TKey>
    {
        TKey id { get; set; }
        DateTime fechaCreacion { get; set; }
        bool esBorrado { get; set; }
        bool esActivo { get; set; }
    }

    public interface IEntity : IEntity<ObjectId>
    {
    }
}
