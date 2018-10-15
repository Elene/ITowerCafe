using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ITowerCafe.Startup))]
namespace ITowerCafe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
