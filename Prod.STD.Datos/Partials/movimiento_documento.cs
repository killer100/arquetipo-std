using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prod.STD.Datos.Modelo
{
    public partial class movimiento_documento
    {
        [ForeignKey("ID_DEPENDENCIA_ORIGEN")]
        public virtual vw_dat_dependencia dependencia_origen { get; set; }

        [ForeignKey("ID_DEPENDENCIA_DESTINO")]
        public virtual vw_dat_dependencia dependencia_destino { get; set; }
    }
}
