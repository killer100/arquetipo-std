using System.Collections.Generic;
using Prod.STD.Entidades;
using Release.Helper.Data.ICore;

namespace Prod.STD.Datos
{
    public interface IUnitOfWorkTemplate : IBaseUnitOfWork
    {
        string XmlOrdenData(string ordenId);
        
    }
}
