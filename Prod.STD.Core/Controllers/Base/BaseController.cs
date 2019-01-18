using Microsoft.AspNetCore.Mvc;
using Prod.STD.Entidades.Comando;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Core.Controllers.Base
{
    public class BaseController : Controller
    {
        protected CommandResponse _Response(string msg = null, int statuscode = 200, Object data = null, IDictionary<string, string> errors = null)
        {
            return new CommandResponse
            {
                statuscode = statuscode,
                msg = msg,
                errors = errors,
                data = data
            };
        }

        protected CommandResponse<T> _Response<T>(string msg = null, int statuscode = 200, T data = null, IDictionary<string, string> errors = null) where T : class
        {
            return new CommandResponse<T>
            {
                statuscode = statuscode,
                msg = msg,
                errors = errors,
                data = data
            };
        }

        protected CommandResponse TryCatch(Func<CommandResponse> action)
        {
            try
            {
                return action();
            }
            catch (AplicationException e)
            {
                return this._Response(e.Message, e.statuscode, null, e.errors);
            }
            catch (Exception e)
            {
                return this._Response("Ocurrió un error interno", 500, null, null);
            }
        }

        protected CommandResponse<T> TryCatch<T>(Func<CommandResponse<T>> action) where T : class
        {
            try
            {
                return action();
            }
            catch (AplicationException e)
            {
                return this._Response<T>(e.Message, e.statuscode, null, e.errors);
            }
            catch (Exception e)
            {
                return this._Response<T>("Ocurrió un error interno", 500, null, null);
            }
        }
    }
}
