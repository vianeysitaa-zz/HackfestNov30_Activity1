using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HackfestNov30_Activity1.Startup))]
namespace HackfestNov30_Activity1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
