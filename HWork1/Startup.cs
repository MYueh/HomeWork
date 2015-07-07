using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HWork1.Startup))]
namespace HWork1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
