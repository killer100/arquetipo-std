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
    
    [Table("DAT_CONTADOR_INTERNO", Schema = "web_tramite")]
    
    public partial class dat_contador_interno
    {
    	[Key()]	
    	public int id { get; set; }
    	public int id_documento { get; set; }
    	public int contador { get; set; }
    	public System.DateTime fecha_registro { get; set; }
    	public int estado { get; set; }
    	public string usuario { get; set; }
    }
}
