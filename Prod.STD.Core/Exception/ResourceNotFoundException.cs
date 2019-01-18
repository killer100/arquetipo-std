using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Core
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException()
        {
        }
        public ResourceNotFoundException(string msg) : base(msg)
        { }
    }
}
