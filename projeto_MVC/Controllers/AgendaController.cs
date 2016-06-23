using projeto_MVC.Dominio;
using projeto_MVC.Handlers;
using projeto_MVC.Services;
using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto_MVC.Controllers
{
    [Autorizador(Roles = "administrador")]
    public class AgendaController : Controller
    {
        private AgendaService agendaService = new AgendaService();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.filtros = agendaService.getFiltros();

            return View();
        }

        [HttpPost]
        public JsonResult Buscar(FiltrosAgenda filtros)
        {
            return Json(agendaService.buscarAgendamentos(filtros));
        }

        [HttpPost]
        public JsonResult Create(Agenda agenda)
        {
            return Json(agendaService.create(agenda));
        }

        [HttpPost]
        public JsonResult Update(Agenda agenda)
        {
            return Json(agendaService.update(agenda));
        }

        [HttpPost]
        public void Delete(long id)
        {
            agendaService.delete(id);
        }
    }
}