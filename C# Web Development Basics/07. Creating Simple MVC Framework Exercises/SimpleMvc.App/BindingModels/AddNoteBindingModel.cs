using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMvc.App.BindingModels
{
    public class AddNoteBindingModel
    {
        public int UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
