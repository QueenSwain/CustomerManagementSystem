using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GitHubProject.Startup))]
namespace GitHubProject
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
