using SimpleMvc.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.Framework.ViewEngine
{
    public class ActionResult : IActionResult
    {
        public ActionResult(string viewFullQualifiedName)
        {
            this.Action = (IRenderable)Activator.CreateInstance(Type.GetType(viewFullQualifiedName));
        }

        public IRenderable Action { get; set; }

        public string Invoke()
        {
            return this.Action.Render();
        }
    }
}
