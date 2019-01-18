using Prod.STD.Entidades.Archivo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion.Interface
{
    public interface IArchivoAplicacion
    {
        ArchivoResponse UploadFileTemp(ArchivoRequest request);
    }
}
