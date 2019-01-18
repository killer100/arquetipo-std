using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Archivo
{
    public class ArchivoResponse
    {
        public string id { get; set; }
        public string fileName { get; set; }
        public string mimetype { get; set; }
        public long size { get; set; }
    }
}
