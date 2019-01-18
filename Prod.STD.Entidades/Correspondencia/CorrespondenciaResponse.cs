using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Correspondencia
{
    public class CorrespondenciaResponse
    {
        public int id_correspondencia { get; set; }
        public string documento { get; set; }
        public string numero { get; set; }
        public string destinatario { get; set; }
        public string domicilio { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public string fecha_entrega_courier { get; set; }
        public string fecha_notificacion { get; set; }
    }
}
