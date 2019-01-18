using Prod.STD.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Prod.STD.Datos.Modelo
{
    public partial class documento
    {
       
        [ForeignKey("ID_PERSONA")]
        public virtual v_persona persona { get; set; }
        [ForeignKey("ID_DOCUMENTO")]
        public virtual ICollection<dat_contador_interno> contador_interno { get; set; }
        [ForeignKey("ID_TUP")]
        public virtual vw_dat_tupa tupa { get; set; }
        [InverseProperty("documento")]
        public virtual ICollection<anexo> anexos { get; set; }
        [ForeignKey("ID_DOCUMENTO")]
        public virtual ICollection<dat_documento_copia> copias { get; set; }
        [NotMapped]
        public int CANT_COPIAS { get; set; }
        [NotMapped]
        public int CANT_ADJUNTOS { get; set; }

        public documento setDocumentoCont(documento_cont documento_cont) {
            if (documento_cont != null) {
                this.CANT_COPIAS = documento_cont.CANT_COPIAS;
                this.CANT_ADJUNTOS = documento_cont.CANT_ADJUNTOS;
            }
            return this;
        }
        [ForeignKey("ID_DOCUMENTO")]
        public virtual ICollection<doc_tipo_tratamiento> doc_tipo_documento { get; set; }
    }
}
