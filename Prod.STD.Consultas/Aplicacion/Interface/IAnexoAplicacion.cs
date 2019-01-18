using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comun;
using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Consultas.Aplicacion.Interface
{
    public interface IAnexoAplicacion
    {
        AnexoResponse GetAnexo(int id);

        PagedResponse<AnexoResponse> SearchAnexos(AnexoFilter filters);


        /// <summary>
        /// Verifica si se puede Actualizar o eliminar el anexo
        /// </summary>
        /// <param name="id_anexo"></param>
        /// <returns></returns>
        bool CheckCanUpdateOrRemove(int id_anexo);
    }
}
