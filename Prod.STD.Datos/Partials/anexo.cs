using Prod.STD.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prod.STD.Datos.Modelo
{
    public partial class anexo
    {
        [ForeignKey("ID_PERSONA_DESTINO")]
        public virtual vw_dat_trabajador persona_destino { get; set; }

        [ForeignKey("ID_PERSONA")]
        public virtual v_persona persona { get; set; }

        [ForeignKey("ID_DOCUMENTO")]
        public virtual documento documento { get; set; }
    }
}
