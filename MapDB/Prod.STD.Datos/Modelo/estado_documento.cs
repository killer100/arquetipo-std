//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prod.STD.Datos.Modelo
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    
    [Table("ESTADO_DOCUMENTO", Schema = "dbo")]
    
    public partial class estado_documento
    {
        
        public estado_documento()
        {
            this.documento = new HashSet<documento>();
        }
    
    	[Key()]	
    	public int ID_ESTADO_DOCUMENTO { get; set; }
    	public string DESCRIPCION { get; set; }
    
        
        public virtual ICollection<documento> documento { get; set; }
    }
}
