using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Attributes.Methods
{
    public abstract class HttpMethodAttribute : Attribute
    {
        public abstract bool IsValid(string requestMethod);
    }
}
