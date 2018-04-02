using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRMS.Employee.Web.Startup))]
namespace HRMS.Employee.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
