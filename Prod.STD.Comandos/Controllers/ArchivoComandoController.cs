using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Core.Controllers.Base;
using Prod.STD.Entidades.Archivo;
using Prod.STD.Entidades.Comando;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Prod.STD.Comandos.Controllers
{
    [Route("[controller]")]
    public class ArchivoComandoController : BaseController
    {
        private readonly IArchivoAplicacion _archivoAplicacion;

        public ArchivoComandoController(IArchivoAplicacion archivoAplicacion)
        {
            _archivoAplicacion = archivoAplicacion;
        }
        public static IConfiguration Configuration;

        [HttpPost, DisableRequestSizeLimit]
        [Route("upload/temp-archivo")]
        public CommandResponse<ArchivoResponse> UploadFile([FromBody]ArchivoRequest request)
        {
            return this.TryCatch(() =>
            {                
                var archivo = _archivoAplicacion.UploadFileTemp(request);
                return _Response(data: archivo);
            });
        }
    }
}
