using IntegrationTestingDemo.Core;
using IntegrationTestingDemo.Domain;
using IntegrationTestingDemo.Infra;
using IntegrationTestingDemo.WebApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Injection;

namespace IntegrationTestingDemo.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<EmployeesDbContext>(new InjectionConstructor());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
