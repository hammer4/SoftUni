using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Book_Library.Startup))]
namespace Book_Library
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
