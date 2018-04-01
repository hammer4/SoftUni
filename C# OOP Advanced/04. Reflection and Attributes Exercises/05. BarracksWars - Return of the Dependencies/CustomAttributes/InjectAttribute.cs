using System;
using System.Collections.Generic;
using System.Text;

namespace _03BarracksFactory.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Field)]
    class InjectAttribute : Attribute
    {
    }
}
