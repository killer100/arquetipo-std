using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.Comun.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Consultas.Aplicacion.Interface
{
    public interface IComunAplicacion
    {
        ICollection<DependenciaResponse> GetDependencias(DependenciaFilter filters);

        ICollection<ClaseDocumentoResponse> GetClasesDocumento(ClaseDocumentoFilter filters);
        ICollection<TipoTratamientoResponse> GetTiposTratamiento();

        ICollection<TipoResolucionResponse> GetTiposResolucion();

        ICollection<ClaseTupaResponse> GetClasesTupa();

        ICollection<TupaResponse> GetTupas(TupaFilter filters);

        ICollection<PersonaResponse> GetPersonas(PersonaFilter filters);

        ICollection<RequisitoTupaResponse> GetRequisitosTupa(int id_tupa);

        ICollection<TipoAnexoResponse> GetTiposAnexo();

        ICollection<TrabajadorResponse> GetTrabajadores(TrabajadorFilter filters);
    }
}
