using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC03.Startup))]
namespace MVC03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
