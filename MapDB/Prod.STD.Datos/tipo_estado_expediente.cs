//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prod.STD.Servicios.Modelo
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
    using System;
    using System.Collections.Generic;
    
    [Table("TIPO_ESTADO_EXPEDIENTE", Schema = "dbo")]
    
    public partial class tipo_estado_expediente
    {
    	[Key()]	
    	public int id_tipo_estado { get; set; }
    	public string descripcion_estado { get; set; }
    	public Nullable<bool> flag { get; set; }
    }
}