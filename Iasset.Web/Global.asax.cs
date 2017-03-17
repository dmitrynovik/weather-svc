using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Iasset.Service;
using Iasset.Service.WeatherProxy;

namespace Iasset.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureIoC();
        }

        private static void ConfigureIoC()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WeatherService>()
                .AsSelf()
                .WithParameter("client", new GlobalWeatherSoapClient("GlobalWeatherSoap"))
                .WithParameter("apiKey", ConfigurationManager.AppSettings["openweathermap.api.key"])
                .InstancePerRequest();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
