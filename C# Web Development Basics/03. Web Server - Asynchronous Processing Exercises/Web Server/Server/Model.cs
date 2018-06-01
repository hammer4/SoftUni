using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server
{
    public class Model
    {
        private readonly Dictionary<string, object> objects;

        public Model()
        {
            this.objects = new Dictionary<string, object>();
        }

        public object this[string key]
        {
            get => this.objects[key];
            set => this.objects[key] = value;
        }

        public void Add(string key, object value)
        {
            this.objects.Add(key, value);
        }
    }
}
