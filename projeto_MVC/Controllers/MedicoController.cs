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
    public class MedicoController : Controller
    {
        private static String[] DIAS_DA_SEMANA = {
                    "Domingo", 
                    "Segunda",
                    "Terça",
                    "Quarta",
                    "Quinta",
                    "Sexta",
                    "Sabado" 
                };

        EspecialidadeService especialidadeService = new EspecialidadeService();
        MedicoService medicoService = new MedicoService();

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Especialidades = especialidadeService.getAll();
            ViewBag.DiasDaSemana = DIAS_DA_SEMANA;


            return View();
        }

        [HttpPost]
        public ActionResult Create(Medico medico)
        {
            if (ModelState.IsValid)
            {
                medicoService.create(medico);
                return RedirectToAction("List");
             }
            else
            {
                ViewBag.Especialidades = especialidadeService.getAll();
                ViewBag.DiasDaSemana = DIAS_DA_SEMANA;
                return View("Create", medico);
            }

        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            Medico medico = medicoService.findById(id);

            List<Especialidade> especialidades = especialidadeService.getAll();
            ViewBag.Especialidades = especialidades;
            ViewBag.DiasDaSemana = DIAS_DA_SEMANA;

            return View(medico);
        }

        [HttpPost]
        public ActionResult Edit(Medico medico)
        {
            if (ModelState.IsValid)
            {
                medicoService.edit(medico);
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Especialidades = especialidadeService.getAll();
                ViewBag.DiasDaSemana = DIAS_DA_SEMANA;
                return View("Edit", medico);
            }
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