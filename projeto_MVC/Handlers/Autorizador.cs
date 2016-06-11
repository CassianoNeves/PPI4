using projeto_MVC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace projeto_MVC.Handlers
{
    public class Autorizador : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Usuario usuario = HttpContext.Current.Session["UsuarioLogado"] as Usuario;

            if (usuario != null)
            {
                if (String.IsNullOrWhiteSpace(this.Roles) || this.Roles.Contains(usuario.Role)) 
                {
                    return true;
                }
            }

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", "Index" },
                                       { "controller", "Login" }
                                   });
        }

    }

}