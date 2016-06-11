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
    [Autorizador(Roles="administrador")]
    public class EspecialidadeController : Controller
    {
        private EspecialidadeService especialidadeService = new EspecialidadeService();

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Especialidade especialidade)
        {
            especialidadeService.create(especialidade);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            List<Especialidade> especialidades = new List<Especialidade>();

            especialidades = especialidadeService.getAll();

            return View(especialidades);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Especialidade especialidade = especialidadeService.findById(id);

            return View(especialidade);
        }

        [HttpPost]
        public ActionResult Edit(Especialidade especialidade)
        {
            especialidadeService.edit(especialidade);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            especialidadeService.delete(id);
            return RedirectToAction("List");
        }
    }
}