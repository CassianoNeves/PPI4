using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto_MVC.Controllers
{
    public class EspecialidadeController : Controller
    {
        // GET: Especialidade
        public ActionResult Index()
        {
            return View();
        }

        // GET: Especialidade
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialidade
        [HttpPost]
        public ActionResult Create(EspecialidadeCreateViewModel especialidadeViewModel)
        {
            return View();
        }
    }
}