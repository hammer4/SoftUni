using Microsoft.EntityFrameworkCore;
using SimpleMvc.Data;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;
using System;

namespace SimpleMvc.App
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing database...");

            using (var context = new SimpleMvcDbContext())
            {
                context.Database.Migrate();
            }

            var server = new WebServer.WebServer(8000, new ControllerRouter());

            MvcEngine.Run(server);
        }
    }
}
