using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Form112.Startup))]
namespace Form112
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
