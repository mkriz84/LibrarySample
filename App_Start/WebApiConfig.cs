using System.Web.Http;
using Library.Controllers;


namespace Library
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            config.EnableCors();
            UnityConfig.ConfigureUnity(config);
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
