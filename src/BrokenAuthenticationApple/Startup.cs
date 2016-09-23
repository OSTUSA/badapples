using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BrokenAuthenticationApple.Startup))]
namespace BrokenAuthenticationApple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
