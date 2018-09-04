using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BehaveTherapy.Startup))]
namespace BehaveTherapy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
