using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApijw2.Startup))]
namespace WebApijw2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
