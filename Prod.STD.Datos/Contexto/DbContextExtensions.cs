using System.Threading.Tasks;

namespace Prod.STD.Datos.Contexto
{
    public partial class STDDbContext
    {
        public void SaveChanges(string jsonAuthN)
        {
            //TODO
        }

        public async Task SaveChangesAsync(string jsonAuthN)
        {
            //TODO
            await Task.Delay(0);
        }

        public void SaveAudit()
        {
            //TODO
        }
    }  
}
