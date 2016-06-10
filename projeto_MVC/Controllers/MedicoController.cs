using projeto_MVC.Dominio;
using projeto_MVC.Services;
using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto_MVC.Controllers
{
    public class MedicoController : Controller
    {
        EspecialidadeService especialidadeService = new EspecialidadeService();
        MedicoService medicoService = new MedicoService();

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Especialidades = especialidadeService.getAll();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            medicoService.create(medico);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Medico medico = medicoService.findById(id);

            List<Especialidade> medicos = especialidadeService.getAll();
            ViewBag.Especialidades = medicos;


            return View(medico);
        }

        [HttpPost]
        public ActionResult Edit(Medico medico)
        {
            medicoService.edit(medico);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            medicoService.delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            List<Medico> medicos = medicoService.getAll();

            return View(medicos);
        }
    }
}