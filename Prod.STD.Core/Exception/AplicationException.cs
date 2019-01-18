using System;
using System.Collections.Generic;

namespace Prod.STD.Core
{
    public class AplicationException : Exception
    {
        public AplicationException(string msg) : base(msg)
        { }
        public int statuscode { get; set; }
        public IDictionary<string, string> errors { get; set; }
    }
}
