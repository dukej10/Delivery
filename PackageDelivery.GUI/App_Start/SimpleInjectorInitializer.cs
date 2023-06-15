[assembly: WebActivator.PostApplicationStartMethod(typeof(PackageDelivery.GUI.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace PackageDelivery.GUI.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using PackageDelivery.Application.Contracts.Interfaces.Core;
    using PackageDelivery.Application.Contracts.Interfaces.Parameters;
    using PackageDelivery.Application.Implementation.Implementation.Core;
    using PackageDelivery.Application.Implementation.Implementation.Parameters;
    using PackageDelivery.Repository.Contracts.Interfaces;
    using PackageDelivery.Repository.Implementation.Implementation.Parameters;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            //#error Register your services here (remove this line).

            // For instance:
            // container.Register<IUserRepository, SqlUserRepository>(Lifestyle.Scoped);
            container.Register<IDepartmentApplication, DepartmentImpApplication>(Lifestyle.Scoped);
            container.Register<IPersonApplication, PersonImpApplication>(Lifestyle.Scoped);
            container.Register<IDocumentTypeApplication, DocumentTypeImpApplication>(Lifestyle.Scoped);
            container.Register<IMunicipalityApplication, MunicipalityImpApplication>(Lifestyle.Scoped);
            container.Register<ITransportTypeApplication, TransportTypeImpApplication>(Lifestyle.Scoped);
            container.Register<IOfficeApplication, OfficeImpApplication>(Lifestyle.Scoped);
            container.Register<IPackageApplication, PackageImpApplication>(Lifestyle.Scoped);
            container.Register<IAddressApplication, AddressImpApplication>(Lifestyle.Scoped);
            container.Register<IShippingStatusApplication, ShippingStatusImpApplication>(Lifestyle.Scoped);

            container.RegisterMvcControllers();


        }
    }
}