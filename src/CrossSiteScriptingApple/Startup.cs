using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossSiteScriptingApple.Startup))]
namespace CrossSiteScriptingApple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
