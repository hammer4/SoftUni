using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Attributes.Methods
{
    public class HttpGetAttribute : HttpMethodAttribute
    {
        public override bool IsValid(string requestMethod)
        {
            return requestMethod == "GET";
        }
    }
}
