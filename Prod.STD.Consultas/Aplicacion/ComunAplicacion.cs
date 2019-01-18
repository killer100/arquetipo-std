using AutoMapper;
using Prod.STD.Consultas.Aplicacion.Interface;
using Prod.STD.Datos;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.Comun.Filters;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Prod.STD.Enumerados;

namespace Prod.STD.Consultas.Aplicacion
{
    public class ComunAplicacion : IComunAplicacion
    {
        private IContext _context;
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ComunAplicacion(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
            _mapper = mapper;
        }

        public ICollection<DependenciaResponse> GetDependencias(DependenciaFilter filters)
        {
            int?[] dependencias_internas = { 2, 5 };

            Expression<Func<Modelo.vw_dat_dependencia, bool>> _where = x =>
                (!filters.activo || x.CONDICION == "ACTIVO") &&
                (!filters.dependencias_internas || dependencias_internas.Contains(x.ID_TIPO_DEPENDENCIA));

            var query = _context.Query<Modelo.vw_dat_dependencia>().Where(_where).OrderBy(x => x.SIGLAS);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.vw_dat_dependencia>, ICollection<DependenciaResponse>>(items);
        }

        public ICollection<ClaseDocumentoResponse> GetClasesDocumento(ClaseDocumentoFilter filters)
        {

            Expression<Func<Modelo.clase_documento_interno, bool>> _where = x =>
             (string.IsNullOrEmpty(filters.procedencia) || x.PROCEDENCIA == filters.procedencia) &&
             (string.IsNullOrEmpty(filters.categoria) || x.categoria == filters.categoria);

            var query = _context.Query<Modelo.clase_documento_interno>().Where(_where).OrderBy(x => x.DESCRIPCION);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.clase_documento_interno>, ICollection<ClaseDocumentoResponse>>(items);
        }

        public ICollection<TipoTratamientoResponse> GetTiposTratamiento()
        {
            var query = _context.Query<Modelo.tipo_tratamiento>().OrderBy(x => x.id_tipo_tratamiento);
            var items = query.ToList();
            return _mapper.Map<ICollection<Modelo.tipo_tratamiento>, ICollection<TipoTratamientoResponse>>(items);
        }

        public ICollection<TipoResolucionResponse> GetTiposResolucion()
        {
            var query = _context.Query<Modelo.tipo_resolucion>().OrderBy(x => x.descrip_completa);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.tipo_resolucion>, ICollection<TipoResolucionResponse>>(items);
        }

        public ICollection<ClaseTupaResponse> GetClasesTupa()
        {
            var query = _context.Query<Modelo.vw_dat_clase_tupa>().OrderBy(x => x.DESCRIPCION);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.vw_dat_clase_tupa>, ICollection<ClaseTupaResponse>>(items);
        }

        public ICollection<TupaResponse> GetTupas(TupaFilter filters)
        {
            Expression<Func<Modelo.vw_dat_tupa, bool>> _where = x => x.CODIGO_DEPENDENCIA != DEPENDENCIA_PRODUCE.UNDEFINED &&
             (filters.estado == null || x.ESTADO_TUPA == filters.estado) &&
             (filters.id_clase_tupa == null || x.ID_CLASE_TUPA == filters.id_clase_tupa);

            var query = _context.Query<Modelo.vw_dat_tupa>().Where(_where).OrderBy(x => x.DESCRIPCION);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.vw_dat_tupa>, ICollection<TupaResponse>>(items);
        }

        public ICollection<PersonaResponse> GetPersonas(PersonaFilter filters)
        {
            Expression<Func<Modelo.v_persona, bool>> _where = x => x.FLAG == "A" &&
             (string.IsNullOrEmpty(filters.nro_documento) || x.NRO_DOCUMENTO.Contains(filters.nro_documento)) &&
             (string.IsNullOrEmpty(filters.razon_social) || (x.RAZON_SOCIAL + " " + x.NOMBRES + " " + x.APELLIDOS).Trim().Contains(filters.razon_social)) &&
             (filters.id_tipo_persona == null || x.ID_TIPO_PERSONA == filters.id_tipo_persona);

            var query = _context.Query<Modelo.v_persona>().Where(_where).OrderBy(x => x.RAZON_SOCIAL).AsQueryable();

            if (filters.limit != null)
                query = query.Take(filters.limit.Value);
            else
                query = query.Take(100);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.v_persona>, ICollection<PersonaResponse>>(items);
        }

        public ICollection<RequisitoTupaResponse> GetRequisitosTupa(int id_tupa)
        {
            var query = _context.Query<Modelo.vw_dat_requisito_tupa>()
                .Where(x => x.ID_TUPA == id_tupa && x.ESTADO == ESTADO_REQUISITO_TUPA.ACTIVO).OrderBy(x => x.ID_REQUISITO);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.vw_dat_requisito_tupa>, ICollection<RequisitoTupaResponse>>(items);
        }

        public ICollection<TipoAnexoResponse> GetTiposAnexo()
        {
            var query = _context.Query<Modelo.tipo_anexo>().OrderBy(x => x.DESCRIPCION);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.tipo_anexo>, ICollection<TipoAnexoResponse>>(items);
        }

        public ICollection<TrabajadorResponse> GetTrabajadores(TrabajadorFilter filters)
        {

            if (filters.codigos_dependencia == null || filters.codigos_dependencia.Count() == 0)
                return new List<TrabajadorResponse>();

            var query = _context.Query<Modelo.vw_dat_trabajador>().Where(x =>
                filters.codigos_dependencia.Contains(x.CODIGO_DEPENDENCIA) &&
                (string.IsNullOrEmpty(filters.estado) || x.ESTADO == filters.estado) &&
                (filters.director == null || x.DIRECTOR == filters.director) &&
                (string.IsNullOrEmpty(filters.nombre) || (x.APELLIDOS_TRABAJADOR + " " + x.NOMBRES_TRABAJADOR).Contains(filters.nombre))
            ).OrderBy(x => x.APELLIDOS_TRABAJADOR);

            var items = query.ToList();

            return _mapper.Map<ICollection<Modelo.vw_dat_trabajador>, ICollection<TrabajadorResponse>>(items);
        }
    }
}
