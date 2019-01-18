using Release.Helper.Data.Core;
using System.Data;

namespace Prod.STD.Datos
{
    public class UnitOfWorkTemplate : BaseUnitOfWork, IUnitOfWorkTemplate
    {
        public UnitOfWorkTemplate(IDbContext ctx)
            : base(ctx, true)
        {
        }

        public string XmlOrdenData(string ordenId)
        {
            string result = null;

            var parameters = new Parameter[]
            {
                new Parameter("@orderid", ordenId, ParameterDirection.Input)
            };

            result = this.ExecuteXmlReader("dbo.USP_OBTENER_ORDEN", CommandType.StoredProcedure, ref parameters);

            return result;
        }
    }
}
