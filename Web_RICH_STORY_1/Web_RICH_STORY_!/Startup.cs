using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web_RICH_STORY__.Startup))]
namespace Web_RICH_STORY__
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
