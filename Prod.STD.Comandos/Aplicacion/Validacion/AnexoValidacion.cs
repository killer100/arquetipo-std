using Prod.STD.Entidades.Anexo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion.Validacion
{
    public class AnexoValidacion
    {
        public IDictionary<string, string> ValidarNuevoAdjunto(AnexoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            if (request.id_documento == null || request.id_documento == 0)
                errors.Add("id_documento", "Debe haber un documento para realizar esta acción");

            if (request.id_persona == null || request.id_persona == 0)
                errors.Add("id_persona", "Debe buscar Razón Social/Apellidos y Nombres");            

            if (request.id_tipo_anexo == null || request.id_tipo_anexo == 0)
                errors.Add("id_tipo_anexo", "Debe seleccionar el tipo de documento");

            if (request.folios == null || request.folios == 0)
                errors.Add("folios", "Debe ingresar la cantidad de folios");

            if (string.IsNullOrEmpty(request.contenido))
                errors.Add("contenido", "Debe ingresar el contenido");

            return errors;
        }

        public IDictionary<string, string> ValidarModificaAdjunto(AnexoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_persona == null || request.id_persona == 0)
                errors.Add("id_persona", "Debe buscar Razón Social/Apellidos y Nombres");

            if (request.id_tipo_anexo == null || request.id_tipo_anexo == 0)
                errors.Add("id_tipo_anexo", "Debe seleccionar el tipo de documento");

            if (request.folios == null || request.folios == 0)
                errors.Add("folios", "Debe ingresar la cantidad de folios");

            if (string.IsNullOrEmpty(request.contenido))
                errors.Add("contenido", "Debe ingresar el contenido");

            return errors;
        }

    }
}
