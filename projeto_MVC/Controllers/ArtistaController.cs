using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto_MVC.Controllers
{
    public class ArtistaController : Controller
    {
        // GET: Artista
        public ActionResult Index()
        {
            return View();
        }
    }
}