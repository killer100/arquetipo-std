using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comando
{
    public class CommandResponse
    {
        public int statuscode { get; set; } = 200;

        public string msg { get; set; }

        public IDictionary<string, string> errors { get; set; }

        public bool success { get; set; }

        public Object data { get; set; }
    }

    public class CommandResponse<T> where T : class
    {
        public int statuscode { get; set; }

        public string msg { get; set; }

        public IDictionary<string, string> errors { get; set; }

        public bool success { get; set; }

        public T data { get; set; }
    }
}
