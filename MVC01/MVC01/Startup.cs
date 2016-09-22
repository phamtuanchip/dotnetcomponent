using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC01.Startup))]
namespace MVC01
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);

        }
    }
}
