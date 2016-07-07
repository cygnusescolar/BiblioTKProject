using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BiblioTK.MVC.Startup))]
namespace BiblioTK.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
