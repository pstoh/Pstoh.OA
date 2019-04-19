using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pstoh.OA.UI.Portal.Startup))]
namespace Pstoh.OA.UI.Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
