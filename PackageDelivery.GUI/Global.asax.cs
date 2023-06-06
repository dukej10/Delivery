using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using PackageDelivery.WebServices.Areas.HelpPage.Controllers;

namespace PackageDelivery.GUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Crear una instancia de HttpConfiguration
            var config = new HttpConfiguration();

            // Configurar las rutas, servicios y otros aspectos de HttpConfiguration

            // Establecer la instancia de HttpConfiguration en la propiedad Configuration de HelpController
            var helpController = DependencyResolver.Current.GetService<HelpController>();
            helpController.Configuration = config;
        }
    }
}
