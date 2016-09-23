using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FunctionLevelAccessControlApple.Startup))]
namespace FunctionLevelAccessControlApple
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
