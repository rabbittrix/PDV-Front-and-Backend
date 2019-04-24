using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaFinanceiro.Startup))]
namespace SistemaFinanceiro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
