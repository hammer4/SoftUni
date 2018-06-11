using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.Interfaces
{
    public interface IActionResult : IInvocable
    {
        IRenderable Action { get; set; }
    }
}
