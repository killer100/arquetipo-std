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
    
    [Table("VW_DAT_CLASE_TUPA", Schema = "web_tramite")]
    
    public partial class vw_dat_clase_tupa
    {
    	[Key()]	
    	public int ID_CLASE_TUPA { get; set; }
    	public string DESCRIPCION { get; set; }
    }
}
