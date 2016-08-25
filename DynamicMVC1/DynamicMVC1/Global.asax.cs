using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DynamicMVC.Data;
using DynamicMVC.Data.Interfaces;
using DynamicMVC.Shared;
using DynamicMVC.Shared.Interfaces;
using DynamicMVC.Shared.Models;
using DynamicMVC.UI.DynamicMVC;
using DynamicMVC.UI.DynamicMVC.Interfaces;
using UnityConfig = DynamicMVC1.App_Start.UnityConfig;

namespace DynamicMVC1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //load mvc container and use it as dynamic mvc container
            var mvcContainer = UnityConfig.GetConfiguredContainer();
            DynamicMVC.Shared.Container.EagerLoadedContainer = mvcContainer;
            DynamicMVC.Shared.UnityConfig.RegisterTypes(mvcContainer);

            DynamicMVCUnityConfig.RegisterTypes(Container.GetConfiguredContainer());
            UnityConfig.RegisterTypes(Container.GetConfiguredContainer());
            ICreateDbContextManager createDbContextManager = new CreateDbContextManager(() => new DynamicMVC1.Models.ApplicationDbContext());
            Container.RegisterInstance(createDbContextManager);
            var applicationMetadataProvider = new ApplicationMetadataProvider(typeof(MvcApplication).Assembly, typeof(MvcApplication).Assembly, typeof(MvcApplication).Assembly);
            Container.RegisterInstance<IApplicationMetadataProvider>(applicationMetadataProvider);
            DynamicMVCContext.DynamicMvcManager = Container.Resolve<IDynamicMvcManager>();
            Container.RegisterInstance(DynamicMVCContext.DynamicMvcManager);

            DynamicMVCContext.DynamicMvcManager.RegisterDynamicMvc();
            DynamicMVCContext.DynamicMvcManager.SetDynamicRoutes(RouteTable.Routes);
            //DynamicMVCContext.DynamicMvcManager.Options.DynamicDropDownRecordLimit = 1;
        }
    }
}
