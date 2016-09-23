using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InjectionApple.Startup))]
namespace InjectionApple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
