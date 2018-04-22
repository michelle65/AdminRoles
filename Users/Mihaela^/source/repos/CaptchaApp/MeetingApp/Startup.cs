using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MeetingApp.Startup))]
namespace MeetingApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
