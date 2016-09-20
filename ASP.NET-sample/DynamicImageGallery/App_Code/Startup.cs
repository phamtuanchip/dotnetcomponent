using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DynamicImageGallery.Startup))]
namespace DynamicImageGallery
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
