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
              defaults: new { siteid = RouteParameter.Optional }
          );

            config.Routes.MapHttpRoute(
             name: "GetDataReportDailyTotal",
             routeTemplate: "api/{controller}/{start}/{end}",
             defaults: new { start = RouteParameter.Optional, end = RouteParameter.Optional }
         );

            config.Routes.MapHttpRoute(
            name: "GetDataStatisticSite",
            routeTemplate: "api/{controller}/{level}/{group}/{group2s}/{meterModel}/{companies}/{status}/{availability}/{calc}/{property}/{takeover}/{usingLogger}/{modelLogger}/{accre}/{approve}",
            defaults: new { level = RouteParameter.Optional, group = RouteParameter.Optional, group2s = RouteParameter.Optional,
                meterModel = RouteParameter.Optional,
                companies = RouteParameter.Optional,
                status = RouteParameter.Optional,
                availability = RouteParameter.Optional,
                calc = RouteParameter.Optional,
                property = RouteParameter.Optional,
                takeover = RouteParameter.Optional,
                usingLogger = RouteParameter.Optional,
                modelLogger = RouteParameter.Optional,
                accre = RouteParameter.Optional,
                approve = RouteParameter.Optional,
            }
        );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
