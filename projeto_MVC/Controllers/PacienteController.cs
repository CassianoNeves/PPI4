using projeto_MVC.Dominio;
using projeto_MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto_MVC.Controllers
{
    public class PacienteController : Controller
    {
        private PacienteService pacienteService = new PacienteService();


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                pacienteService.create(paciente);
                return RedirectToAction("List");
            }

            return View("Create", paciente);
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            if (id != 0)
            {
                Paciente paciente = pacienteService.findById(id);
                return View(paciente);
            }

            return View("List");
        }

        [HttpPost]
        public ActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                pacienteService.edit(paciente);
                return RedirectToAction("List");
            }

            return View("Edit", paciente);
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            pacienteService.delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            List<Paciente> pacientes = pacienteService.getAll();
            return View(pacientes);
        }
    }
}