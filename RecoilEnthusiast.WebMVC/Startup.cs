using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecoilEnthusiast.WebMVC.Startup))]
namespace RecoilEnthusiast.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
