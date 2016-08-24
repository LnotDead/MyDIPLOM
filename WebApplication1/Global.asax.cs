using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

            public override void Init()
        {
            base.Init();
            this.BeginRequest += GlobalBeginRequest;
        }

        private void GlobalBeginRequest(object sender, EventArgs e)
        {
            var runTime = (HttpRuntimeSection)WebConfigurationManager.GetSection("system.web/httpRuntime");
            var maxRequestLength = runTime.MaxRequestLength * 1024;

            if (Request.ContentLength > maxRequestLength)
            {
                // пока не знаю, как обработать превыение размера запроса
                //
                Request.Abort();
                Response.Redirect("http://www.microsoft.com");
                // то, что выше, не помогает
            }
        }


    }
    
}
