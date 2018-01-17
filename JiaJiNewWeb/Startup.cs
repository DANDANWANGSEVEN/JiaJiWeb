using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JiaJiNewWeb.Startup))]
namespace JiaJiNewWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
