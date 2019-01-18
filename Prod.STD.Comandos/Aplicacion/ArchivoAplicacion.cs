using Microsoft.Extensions.Configuration;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Entidades._Base;
using Prod.STD.Entidades.Archivo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion
{
    public class ArchivoAplicacion : IArchivoAplicacion
    {
        public static IConfiguration Configuration;
        private readonly AppSettings _appSettings;

        public ArchivoAplicacion(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public ArchivoResponse UploadFileTemp(ArchivoRequest request)
        {
            string path = _appSettings.RemotePathTempDocs;

            string guid = Guid.NewGuid().ToString();
            string newPath = Path.Combine(path, guid);
            if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);            
            if (request.size > 0)
            {
                string fullPath = Path.Combine(newPath, request.fileName);               
                File.WriteAllBytes(fullPath, request.content);                
            }
            var archivo = new ArchivoResponse { id = guid, fileName = request.fileName, mimetype = request.mimetype, size = request.size };

            return archivo;
        }
    }
}
