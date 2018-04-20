using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MondlyBoardGame.Startup))]
namespace MondlyBoardGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
