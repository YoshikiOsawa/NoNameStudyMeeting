using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HiraganaHenkan_CSharp.Startup))]
namespace HiraganaHenkan_CSharp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
