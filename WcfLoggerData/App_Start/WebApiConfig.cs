using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WcfLoggerData
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
               name: "GetDataGraph",
               routeTemplate: "api/{controller}/{siteid}/{start}/{end}",
               defaults: new { siteid = RouteParameter.Optional, start = RouteParameter.Optional, end = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
              name: "GetTime",
              routeTemplate: "api/{controller}/{siteid}",
              defaults: new { siteid = RouteParameter.Optional}
          );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
