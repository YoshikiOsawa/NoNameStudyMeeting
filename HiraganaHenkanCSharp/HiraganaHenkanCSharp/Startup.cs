using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HiraganaHenkanCSharp.Startup))]
namespace HiraganaHenkanCSharp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
