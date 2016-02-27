using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ScottishPremierLeauge.Startup))]
namespace ScottishPremierLeauge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
