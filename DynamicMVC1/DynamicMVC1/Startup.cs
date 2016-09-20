using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicMVC1.Startup))]
namespace DynamicMVC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
