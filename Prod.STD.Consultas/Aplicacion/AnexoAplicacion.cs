using AutoMapper;
using Prod.STD.Consultas.Aplicacion.Interface;
using Prod.STD.Datos;
using Prod.STD.Entidades.Anexo;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;
using Prod.STD.Core;
using Microsoft.EntityFrameworkCore;
using Prod.STD.Core.Resources;
using Release.Helper.Pagination;
using System.Linq.Expressions;
using Prod.STD.Enumerados;
using Prod.STD.Entidades.Comun;

namespace Prod.STD.Consultas.Aplicacion
{
    public class AnexoAplicacion : IAnexoAplicacion
    {
        private IContext _context;
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public AnexoAplicacion(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
            _mapper = mapper;
        }
        public AnexoResponse GetAnexo(int id)
        {
            var anexo = _context.Query<Modelo.anexo>()
                .Include(x => x.tipo_anexo)
                .Include(x => x.persona)
                .Include(x => x.persona_destino).ThenInclude(x => x.dependencia)
                .Where(x => x.ID_ANEXO == id).FirstOrDefault();

            if (anexo == null)
                xHelper.Abort(404, Messages.RESOURCE_NOT_FOUND);

            return _mapper.Map<Modelo.anexo, AnexoResponse>(anexo);
        }

        public PagedResponse<AnexoResponse> SearchAnexos(AnexoFilter filters)
        {
            var trabajadores = _context.Query<Modelo.vw_dat_trabajador>().Select(x => new { x.CODIGO_TRABAJADOR, x.CODIGO_DEPENDENCIA });

            Expression<Func<Modelo.anexo, bool>> _where = x =>
                x.ESTADO_ADJUNTO != ESTADO_ADJUNTO.ANULADO &&
                (string.IsNullOrEmpty(filters.num_documento_anexo) || x.NUM_DOCUMENTO_ANEXO.Contains(filters.num_documento_anexo)) &&
                (filters.coddep_oficina_derivada == null || trabajadores.Any(t => t.CODIGO_DEPENDENCIA == filters.coddep_oficina_derivada && t.CODIGO_TRABAJADOR == x.ID_PERSONA_DESTINO)) &&
                (filters.fecha_inicio == null || x.AUDIT_MOD >= filters.fecha_inicio.Value.Date) &&
                (filters.fecha_fin == null || x.AUDIT_MOD < filters.fecha_fin.Value.Date.AddDays(1));

            var query = _context.Query<Modelo.anexo>()
                .Include(x => x.tipo_anexo)
                .Include(x => x.persona)
                .Where(_where)
                .OrderByDescending(x => x.AUDIT_MOD);

            var page = query.PagedResponse<Modelo.anexo, AnexoResponse>(filters, _mapper);

            page.Data.ToList().ForEach(x =>
            {
                var persona_destino = _context.Query<Modelo.vw_dat_trabajador>()
                    .Include(t => t.dependencia)
                    .Where(t => t.CODIGO_TRABAJADOR == x.id_persona_destino)
                    .FirstOrDefault();
                x.persona_destino = _mapper.Map<Modelo.vw_dat_trabajador, TrabajadorResponse>(persona_destino);
                x.PuedeEditarOAnular = this.CheckCanUpdateOrRemove(x.id_anexo.Value);
            });

            return page;
        }


        public bool CheckCanUpdateOrRemove(int id_anexo)
        {
            var anexo = _context.Query<Modelo.anexo>().Where(x => x.ID_ANEXO == id_anexo).FirstOrDefault();

            if (anexo == null)
                return false;

            //============================================================================
            // NUEVA LOGICA DE ANEXOS, SE BUSCA POR EL CAMPO ID_DOCUMENTO_ADJUNTO
            //============================================================================
            if (anexo.ID_DOCUMENTO_ADJUNTO == null) return true;

            var movimiento = _context.Query<Modelo.movimiento_documento>().Where(x => x.ID_OFICIO == anexo.ID_DOCUMENTO_ADJUNTO).FirstOrDefault();

            return movimiento == null ? true : movimiento.AUDIT_REC == null;
            /*
            else
            {
                //============================================================================
                // ANTIGUA LOGICA DE ANEXOS, LOGICA PESADA
                //============================================================================
                var documento_adjunto = _context.Query<Modelo.documento>().Where(x => x.INDICATIVO_OFICIO.Trim() == "ADJUNTO" && x.ASUNTO.Trim().Contains(anexo.NUM_DOCUMENTO_ANEXO)).FirstOrDefault();
                if (documento_adjunto != null)
                {
                    var movimiento = _context.Query<Modelo.movimiento_documento>().Where(x => x.ID_OFICIO == documento_adjunto.ID_DOCUMENTO).FirstOrDefault();

                    if (movimiento == null) return true;

                    else return movimiento.AUDIT_REC == null;
                }
                else
                {
                    return true;
                }

            }*/
        }
    }
}
