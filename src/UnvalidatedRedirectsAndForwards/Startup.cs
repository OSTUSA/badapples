using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnvalidatedRedirectsAndForwards.Startup))]
namespace UnvalidatedRedirectsAndForwards
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
