using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prod.STD.Datos.Modelo
{
    public partial class vw_dat_trabajador
    {
        [ForeignKey("CODIGO_DEPENDENCIA")]
        public virtual vw_dat_dependencia dependencia { get; set; }
    }
}
