using Prod.STD.Datos;
using Release.Helper.Data.ICore;
using System;
using System.Linq;
using Modelo = Prod.STD.Datos.Modelo;

namespace Prod.STD.Comandos.Aplicacion.Proceso
{
    public class ContadorProceso
    {
        private IContext _context;
        private IUnitOfWork _uow;

        public ContadorProceso(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
        }

        public string EjecutarRegistrarExterno(int year, string username, string hostname)
        {
            var contador = new Modelo.contador
            {
                AUDITMOD = DateTime.Now,
                hostname = hostname,
                usuario = username,
                cont = _context.Query<Modelo.contador>().Max(x => x.cont) + 1
            };
            //System.Environment.MachineName;
            _context.Add(contador);
            _uow.Save();
            var numero = $"{contador.cont}".PadLeft(8, '0');
            return $"{numero}-{year}";
        }

        public string EjecutarRegistrarInterno(int year, int? id_tipo_documento, string username)
        {
            var trabajador = _context.Query<Modelo.vw_dat_trabajador>().Where(x => x.EMAIL == username && x.ESTADO == "ACTIVO").FirstOrDefault();
            var dependencia = _context.Query<Modelo.vw_dat_dependencia>().Where(x => x.CODIGO_DEPENDENCIA == trabajador.CODIGO_DEPENDENCIA && x.CONDICION == "ACTIVO").FirstOrDefault();
            var contador = new Modelo.cuentainterno
            {
                coddep = dependencia.CODIGO_DEPENDENCIA,
                id_tipo_documento = (int)id_tipo_documento,
                contador = _context.Query<Modelo.cuentainterno>()
                            .Where(x=> x.coddep == dependencia.CODIGO_DEPENDENCIA && x.id_tipo_documento == id_tipo_documento)
                            .DefaultIfEmpty()
                            .Max(x=>x.contador) + 1
            };
            _context.Add(contador);
            _uow.Save();
            var numero = $"{contador.contador}".PadLeft(8, '0');
            return $"{numero}-{year}-PRODUCE/{dependencia.SIGLAS}";
        }

        public string EjecutarRegistrarInternoTrabajador()
        {
            return "";
        }
    }
}
