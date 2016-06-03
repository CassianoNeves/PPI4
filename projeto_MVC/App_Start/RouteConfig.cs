using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace projeto_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Agenda", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "EspecialidadeCreate",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Especialidade", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "MedicoCreate",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Medico", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}
