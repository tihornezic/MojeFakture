using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MojeFakture.Startup))]
namespace MojeFakture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
