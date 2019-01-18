using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prod.STD.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Core
{
    public static class xHelper
    {
        public static T ConvertToViewModel<T>(object obj) where T : class
        {
            var mo = JsonConvert.DeserializeObject<T>(JObject.FromObject(obj).ToString());
            return mo;
        }

        public static void Abort(int statuscode, string msg, IDictionary<string, string> errors = null)
        {
            var e = new AplicationException(msg);
            e.errors = errors;
            e.statuscode = statuscode;
            throw e;
        }

        public static void AbortWithValidationErrors(IDictionary<string, string> errors)
        {
            var e = new AplicationException(Messages.COMPLETE_REQUIRED_FIELDS);
            e.errors = errors;
            e.statuscode = 406;
            throw e;
        }

        public static void AbortWithInternalError()
        {
            var e = new AplicationException(Messages.INTERNAL_ERROR);
            e.statuscode = 500;
            throw e;
        }

        public static void AbortWithResourceNotFound()
        {
            var e = new AplicationException(Messages.RESOURCE_NOT_FOUND);
            e.statuscode = 404;
            throw e;
        }

        public static void AbortWithInvalidRequest()
        {
            var e = new AplicationException(Messages.INVALID_REQUEST);
            e.statuscode = 400;
            throw e;
        }


    }
}
