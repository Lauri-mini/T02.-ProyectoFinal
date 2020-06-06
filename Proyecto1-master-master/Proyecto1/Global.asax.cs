using Proyecto1.Clase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Proyecto1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            this.CheckRoutes();
            Utilities.CheckSuperUser();
            Utilities.CheckClientDefault();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void CheckRoutes()
        {
            Utilities.CheckRoles("Admin");
            Utilities.CheckRoles("Visitor");
        }
    }
}
