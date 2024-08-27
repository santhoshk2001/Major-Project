using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ECommerceAppDemo.API.Repositories;
using ECommerceAppDemo.API.Services;
using Unity;
using Unity.Lifetime;
using Unity.Exceptions;
using System.Web.Http.Dependencies;
using System.Web.Http.Cors;

namespace ECommerceAppDemo.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           

            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ProductService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            var cors = new EnableCorsAttribute("https://localhost:44368", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

          


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
