using Prod.STD.Entidades.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Aplicacion.Validacion
{
    public class DocumentoValidacion
    {
        public IDictionary<string, string> ValidarNuevoDocumentoExterno(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_persona == null || request.id_persona == 0)
                errors.Add("id_persona", "Debe buscar Razón Social/Apellidos y Nombres");

            if (string.IsNullOrEmpty(request.asunto))
                errors.Add("asunto", "Ingrese el asunto");

            if (string.IsNullOrEmpty(request.indicativo_oficio))
                errors.Add("indicativo_oficio", "Ingrese el indicativo");

            if (request.id_clase_documento_interno == null || request.id_clase_documento_interno == 0)
                errors.Add("id_clase_documento_interno", "Seleccione la clase de documento");

            if (request.folios == null || request.folios == 0)
                errors.Add("folios", "Ingrese la cantidad de folios");

            if (request.oficina_derivada == null || request.oficina_derivada == 0)
                errors.Add("oficina_derivada", "Seleccione el destinatario");

            return errors;
        }

        public IDictionary<string, string> ValidarNuevoDocumentoInterno(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
           
            if (request.id_clase_documento_interno == null || request.id_clase_documento_interno == 0)
                errors.Add("id_clase_documento_interno", "Seleccione la clase de documento");
            if (request.coddeps_destino.Count == 0 )
                errors.Add("coddeps_destino", "Debe seleccionar al menos una dependencia.");
            if (string.IsNullOrEmpty(request.asunto))
                errors.Add("asunto", "Ingrese el asunto");
            if (request.acciones.Count == 0)
                errors.Add("acciones", "Debe seleccionar al menos una acción a realizar.");
            if (request.folios == null)
                errors.Add("folios", "Ingresar la cantidad de folios.");
            if (request.es_documento_respuesta)
                if (request.referencias.Count == 0)
                    errors.Add("referencias", "Debe ingresar al menos una referencia.");
            if (request.tiene_adjuntos)
                if (request.adjuntos.Count == 0)
                    errors.Add("adjuntos", "Debe subir al menos un adjunto.");
            return errors;
        }

        public IDictionary<string, string> ValidarNuevoDocumentoTupa(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_persona == null || request.id_persona == 0)
                errors.Add("id_persona", "Debe buscar Razón Social/Apellidos y Nombres");

            if (request.id_tup == null || request.id_tup == 0)
                errors.Add("id_tup", "Debe seleccionar un procedimiento");
            else if (request.requisitos == null || request.requisitos.Count == 0)
                errors.Add("id_tup", "Debe seleccionar un procedimiento");

            if (request.id_clase_documento_interno == null || request.id_clase_documento_interno == 0)
                errors.Add("id_clase_documento_interno", "Seleccione la clase de documento");

            if (request.folios == null || request.folios == 0)
                errors.Add("folios", "Ingrese la cantidad de folios");

            if (string.IsNullOrEmpty(request.indicativo_oficio))
                errors.Add("indicativo_oficio", "Ingrese el indicativo");

            return errors;
        }

        public IDictionary<string, string> ValidarActualizarDocumentoExterno(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_persona == null || request.id_persona == 0)
                errors.Add("id_persona", "Debe buscar Razón Social/Apellidos y Nombres");

            if (string.IsNullOrEmpty(request.asunto))
                errors.Add("asunto", "Ingrese el asunto");

            if (string.IsNullOrEmpty(request.indicativo_oficio))
                errors.Add("indicativo_oficio", "Ingrese el indicativo");

            if (request.id_clase_documento_interno == null || request.id_clase_documento_interno == 0)
                errors.Add("id_clase_documento_interno", "Seleccione la clase de documento");

            if (request.folios == null || request.folios == 0)
                errors.Add("folios", "Ingrese la cantidad de folios");

            if (request.oficina_derivada == null || request.oficina_derivada == 0)
                errors.Add("oficina_derivada", "Seleccione el destinatario");

            return errors;
        }

        public IDictionary<string, string> ValidarActualizarDocumentoTupa(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_persona == null || request.id_persona == 0)
                errors.Add("id_persona", "Debe buscar Razón Social/Apellidos y Nombres");

            if (request.id_tup == null || request.id_tup == 0)
                errors.Add("id_tup", "Debe seleccionar un procedimiento");
            else if (request.requisitos == null || request.requisitos.Count == 0)
                errors.Add("id_tup", "Debe seleccionar un procedimiento");

            if (request.id_clase_documento_interno == null || request.id_clase_documento_interno == 0)
                errors.Add("id_clase_documento_interno", "Seleccione la clase de documento");

            if (request.folios == null || request.folios == 0)
                errors.Add("folios", "Ingrese la cantidad de folios");

            if (string.IsNullOrEmpty(request.indicativo_oficio))
                errors.Add("indicativo_oficio", "Ingrese el indicativo");

            return errors;
        }

        public IDictionary<string, string> ValidarAnularDocumento(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_documento == null || request.id_documento == 0)
                errors.Add("id_documento", "Debe haber seleccionado un documento");

            if (string.IsNullOrEmpty(request.observaciones))
                errors.Add("motivo", "Debe ingresar un motivo");

            return errors;
        }

        public IDictionary<string, string> ValidarReactivarDocumento(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_documento == null || request.id_documento == 0)
                errors.Add("id_documento", "Debe haber seleccionado un documento");

            if (request.oficina_derivada == null || request.oficina_derivada == 0)
                errors.Add("oficina_derivada", "Debe seleccionar una dependencia");

            if (string.IsNullOrEmpty(request.observaciones))
                errors.Add("observaciones", "Debe ingresar un motivo");

            return errors;
        }

        public IDictionary<string, string> ValidarCopiasDocumento(DocumentoRequest request)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (request.id_documento == null || request.id_documento == 0)
                errors.Add("id_documento", "Debe haber seleccionado un documento");

            if (request.copias == null || request.copias.Count == 0)
                errors.Add("copias", "Debe seleccionar al menos una dependencia");

            return errors;
        }
    }
}
