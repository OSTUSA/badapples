using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CrossSiteRequestForgeryApple.Startup))]
namespace CrossSiteRequestForgeryApple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
