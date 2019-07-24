using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ObligatorioP2.Startup))]
namespace ObligatorioP2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
