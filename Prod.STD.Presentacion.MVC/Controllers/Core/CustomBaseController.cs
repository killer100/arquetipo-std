using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Prod.STD.Entidades.Comando;
using Release.Helper.WebKoMvc.Controllers;
using System;
using Http = Microsoft.AspNetCore.Http;

namespace Prod.STD.Presentacion.MVC.Controllers
{
    public class CustomBaseController : BaseController
    {
        public static Prod.Seguridad.Auth.Model.Usuario UserAuth;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            UserAuth = GetUser();
        }


        protected Prod.Seguridad.Auth.Model.Usuario GetUser()
        {
            var u = this.GetUserInfo<Prod.Seguridad.Auth.Model.CanjearTokenResponse>();
            return u?.Usuario;
        }
        protected Prod.Seguridad.Auth.Model.Rol[] GetRoles()
        {
            var u = this.GetUserInfo<Prod.Seguridad.Auth.Model.CanjearTokenResponse>();
            return u?.RolesUsuario;
        }

        protected string GetEncodedUser()
        {
            var user = this.GetUser();
            var JsonUser = JsonConvert.SerializeObject(user);
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(JsonUser);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        protected ActionResult _Response(Object data = null, int statuscode = Http.StatusCodes.Status200OK, string msg = null, Object errors = null)
        {
            var response = new
            {
                statuscode,
                msg,
                data,
                errors
            };
            Response.StatusCode = statuscode;

            return new JsonResult(response);
        }

        protected ActionResult _Response(CommandResponse commandResponse)
        {
            var response = new
            {
                commandResponse.statuscode,
                commandResponse.msg,
                commandResponse.errors
            };
            Response.StatusCode = commandResponse.statuscode;
            return new JsonResult(response);
        }

        protected ActionResult _Response<T>(CommandResponse<T> commandResponse) where T : class
        {
            var response = new
            {
                commandResponse.statuscode,
                commandResponse.msg,
                commandResponse.errors,
                commandResponse.data
            };
            this.HttpContext.Response.StatusCode = commandResponse.statuscode;

            return new JsonResult(response);
        }
    }


}
