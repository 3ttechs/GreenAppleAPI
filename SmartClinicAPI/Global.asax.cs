using System.Web;
using System.Web.Http;

namespace SmartClinicAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
          
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            if ( Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
    }
}
