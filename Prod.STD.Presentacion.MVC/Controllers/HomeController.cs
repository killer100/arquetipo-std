using Microsoft.AspNetCore.Mvc;
using Prod.STD.Entidades;
using Prod.STD.Presentacion.Configuracion.Proxys;
using Release.Helper.WebKoMvc.Controllers;
using System.Linq;

namespace Prod.STD.Presentacion.MVC.Controllers
{
    public partial class HomeController : CustomBaseController
    {
        private readonly ComunConsultaProxy _comun;

        public HomeController(ComunConsultaProxy comun)
        {
            _comun = comun;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var user = this.GetEncodedUser();
            ViewBag.user = user;
            return View();
        }



    }
}
