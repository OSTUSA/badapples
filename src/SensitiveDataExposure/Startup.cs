using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SensitiveDataExposure.Startup))]
namespace SensitiveDataExposure
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
