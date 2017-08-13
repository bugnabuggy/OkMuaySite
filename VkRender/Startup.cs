using Owin;

namespace OkMuay
{
    public partial class Startup
    {
		public void Configuration(IAppBuilder app)
		{
		   ConfigureAuth(app);
		}
    }
}
