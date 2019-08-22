using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Expediente_Electronico.Startup))]
namespace Expediente_Electronico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
