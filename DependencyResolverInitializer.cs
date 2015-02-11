using System.Web.Mvc;
using BreakfastCalendar.Business.Abstractions;
using BreakfastCalendar.Business.ModelBuilder;
using BreakfastCalendar.Business.Repository;
using BreakfastCalendar.Business.Repository.Interface;
using BreakfastCalendar.Business.Settings;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using StructureMap;
using StructureMap.Pipeline;

namespace BreakfastCalendar.Infrastructure.Initialization
{
    [ModuleDependency(typeof(ServiceContainerInitialization))]
    [InitializableModule]
    public class DependencyResolverInitializer : IConfigurableModule
    {
        /// <summary>
        ///     Registers additional dependecies to the IoC container
        /// </summary>
        /// <param name="context"></param>
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Container.Configure(x =>
            {
                x.For<ISiteRouteHelper>()
                    .LifecycleIs(Lifecycles.GetLifecycle(InstanceScope.PerRequest))
                    .Use<SiteRouteHelper>();
                x.For<IPublicPageLoader>().Singleton().Use<PublicPageLoader>();
                x.For<ILanguageContext>().Use<LanguageContext>();
                x.For<ISiteUrlResolver>().Use<SiteUrlResolver>();
                x.For<ISiteSettings>().Use<SiteSettings>();
                x.For<ICalendarPageModelBuilder>().Use<CalendarPageModelBuilder>();
                x.For<IProductRepository>().Use<ProductRepository>();
            });

            DependencyResolver.SetResolver(new StructureMapDependencyResolver(context.Container));
        }


        public void Initialize(InitializationEngine context)
        {
           
        }

        public void Uninitialize(InitializationEngine context)
        {
        }

        public void Preload(string[] parameters)
        {
        }
    }
}