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
    
    [Table("resolucion", Schema = "web_tramite")]
    
    public partial class resolucion
    {
    	[Key()]	
    	public int id { get; set; }
    	public string nro_resol { get; set; }
    	public Nullable<int> id_documento { get; set; }
    	public string flag { get; set; }
    	public string sumilla { get; set; }
    	public Nullable<int> id_tipo_resolucion { get; set; }
    	public Nullable<System.DateTime> auditmod { get; set; }
    	public string usuario { get; set; }
    	public Nullable<System.DateTime> auditmod2 { get; set; }
    	public string usuario2 { get; set; }
    	public string FIni { get; set; }
    	public string FFin { get; set; }
    	public string FPublicacion { get; set; }
    	public Nullable<int> coddep { get; set; }
    	public string FFirma { get; set; }
    	public string FErratas { get; set; }
    }
}
