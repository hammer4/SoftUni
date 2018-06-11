using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Interfaces.Generic
{
    public interface IRenderable<T> : IRenderable
    {
        T Model { get; set; }
    }
}
