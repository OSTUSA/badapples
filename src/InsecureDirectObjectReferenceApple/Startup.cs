using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InsecureDirectObjectReferenceApple.Startup))]
namespace InsecureDirectObjectReferenceApple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
