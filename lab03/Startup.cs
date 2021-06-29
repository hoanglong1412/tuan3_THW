using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab03.Startup))]
namespace lab03
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
