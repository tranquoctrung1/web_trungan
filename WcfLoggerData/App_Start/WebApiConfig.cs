﻿using System;
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

            config.Routes.MapHttpRoute(
            name: "GetDataStatisticMeter",
            routeTemplate: "api/{controller}/{provider}/{nation}/{mark}/{size}/{model}/{status}/{install}/{siteStatus}/{company}",
            defaults: new
            {
                provider = RouteParameter.Optional,
                nation = RouteParameter.Optional,
                mark = RouteParameter.Optional,
                size = RouteParameter.Optional,
                model = RouteParameter.Optional,
                status = RouteParameter.Optional,
                install = RouteParameter.Optional,
                siteStatus = RouteParameter.Optional,
                company = RouteParameter.Optional,
            }
        );

            config.Routes.MapHttpRoute(
            name: "GetDataStatisticTransmiiter",
            routeTemplate: "api/{controller}/{provider}/{mark}/{size}/{model}/{status}/{install}/{siteStatus}/{company}",
            defaults: new
            {
                provider = RouteParameter.Optional,
                mark = RouteParameter.Optional,
                size = RouteParameter.Optional,
                model = RouteParameter.Optional,
                status = RouteParameter.Optional,
                install = RouteParameter.Optional,
                siteStatus = RouteParameter.Optional,
                company = RouteParameter.Optional,
            }
        );

            config.Routes.MapHttpRoute(
            name: "GetDataStatisticLogger",
            routeTemplate: "api/{controller}/{provider}/{mark}/{model}/{status}/{install}/{siteStatus}/{company}",
            defaults: new
            {
                provider = RouteParameter.Optional,
                mark = RouteParameter.Optional,
                model = RouteParameter.Optional,
                status = RouteParameter.Optional,
                install = RouteParameter.Optional,
                siteStatus = RouteParameter.Optional,
                company = RouteParameter.Optional,
            }
        );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
        }
    }
}
