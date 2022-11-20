using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(krtrading.Startup))]
namespace krtrading
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
