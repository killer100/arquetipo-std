using Prod.STD.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prod.STD.Datos.Modelo
{
    public partial class dat_documento_copia
    {
        [ForeignKey("CODDEP")]
        public virtual vw_dat_dependencia dependencia { get; set; }
    }
}
