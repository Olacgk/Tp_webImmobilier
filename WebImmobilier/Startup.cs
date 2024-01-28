using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebImmobilier.Startup))]
namespace WebImmobilier
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
