using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TotalControl.Startup))]
namespace TotalControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
