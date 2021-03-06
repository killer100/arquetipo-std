﻿using Prod.STD.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoIngresado
{
    public class DocumentoIngresadoResponse
    {
        public int? id_documento { get; set; }
        public int id_anexo { get; set; }
        public int tipo_registro { get; set; }
        public string numero_tramite { get; set; }
        public string razon_social { get; set; }
        public string asunto { get; set; }
        public int? folios { get; set; }
        public int? coddep { get; set; }
        public DateTime? fecha_registro { get; set; }
        public string fecha_registro_v { get; set; }
        public string usuario { get; set; }
        public string estado_documento { get; set; }
        public string ruta { get; set; }
        public string pdf { get; set; }
        public DateTime? audit_rec { get; set; }
        public string documento_digitalizado { get; set; }
        public int? numero_reporte { get; set; }

        public string tipo_registro_format
        {
            get
            {
                switch (tipo_registro)
                {
                    case 1:
                        return "REGISTRO";
                    case 2:
                        return "ADJUNTO";
                    case 3:
                        return "COPIA";
                    default:
                        return "";
                }
            }
        }

        public DependenciaResponse dependencia { get; set; }
        public bool esTupa { get; set; }

        public string asunto_format
        {
            get
            {
                if (esTupa && id_anexo == 0)
                    return $"TUPA N° {asunto}";
                else return asunto;
            }
        }

        public string numero_reporte_full
        {
            get
            {
                if (numero_reporte == null) return null;

                return $"{numero_reporte}-{fecha_registro.Value.Year}";
            }

        }
    }
}
