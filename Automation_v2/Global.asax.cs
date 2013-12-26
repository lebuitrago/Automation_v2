using Funq;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Automation_v2
{
    public class MvcApplication : System.Web.HttpApplication
    {

        // The base entrypoint for ServiceStack is an applicationhost, in ServiceStack terms AppHost. 
        // The concept of the applicationhost is to have a central point for configurations in your application.
        public class AppHost : AppHostBase
        {
            public AppHost()
                : base("MTAS Automation", typeof(AppHost).Assembly)
            {
            }

            public override void Configure(Container container)
            {
                SetConfig(new HostConfig
                {
                    //This is needed since you will be hosting your services from /api
                    HandlerFactoryPath = "api"
                });
            }
        }

        // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
        // visit http://go.microsoft.com/?LinkId=9394801
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //Ignore anything with /api/* this is to use ServiceStack webservices
            RouteTable.Routes.IgnoreRoute("api/{*pathInfo}");
            //Prevent exceptions for favicon
            RouteTable.Routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            //BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);

            //This will make sure your applicationhost is running inside your webapplication
            new AppHost().Init();
        }
    }
}