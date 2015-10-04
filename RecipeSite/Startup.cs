using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeSite.Startup))]
namespace RecipeSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
