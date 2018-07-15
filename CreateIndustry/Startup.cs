using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CreateIndustry.Startup))]
namespace CreateIndustry
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
