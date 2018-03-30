using Sixty.Helpers;
using Sixty.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sixty
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NHibernateHelper.Instance.Initialize(HttpContext.Current.Server.MapPath(@"bin"));

            RegisterManagers();
        }

        private void RegisterManagers()
        {
            ManagerProvider.Instance.Register(new UserManager());
            ManagerProvider.Instance.Register(new TeamManager());
            ManagerProvider.Instance.Register(new DivisionManager());
        }
    }
}
