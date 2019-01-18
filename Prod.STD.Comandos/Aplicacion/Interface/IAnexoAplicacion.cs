using Prod.STD.Entidades.Anexo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion.Interface
{
    public interface IAnexoAplicacion
    {
        string GetNuevoNumero(int id_documento);
        AnexoResponse SaveAnexo(AnexoRequest request);
        void UpdateAnexo(int id_anexo, AnexoRequest request);
        void AnularAnexo(AnexoRequest request);
    }
}
