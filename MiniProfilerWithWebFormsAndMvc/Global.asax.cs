using StackExchange.Profiling;
using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MiniProfilerWithWebFormsAndMvc
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        /// <summary>
        /// Trigger actions that should happen at the start of every request
        /// </summary>
        protected void Application_BeginRequest()
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains("EnableMiniProfiler"))
            {
                MiniProfiler.Start();
            }
        }

        protected void Application_EndRequest()
        {
            MiniProfiler.Stop();
        }
    }
}