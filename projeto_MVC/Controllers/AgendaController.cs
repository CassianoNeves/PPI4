﻿using projeto_MVC.Dominio;
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
            Agenda agendaCreated = agendaService.create(agenda);

            if (agendaCreated.Id == -1)
            {
                Response.StatusCode = 400;
                return Json("NO_CONSULTA_IN_LAST_DAYS");
            }

            if (agendaCreated.Id == -2)
            {
                Response.StatusCode = 400;
                return Json("EXISTS_CONSULTA_IN_DATE");
            }

            return Json(agendaCreated);
        }

        [HttpPost]
        public JsonResult Update(Agenda agenda)
        {
            Agenda agendaUpdated = agendaService.update(agenda);


            if (agendaUpdated.Id == -1)
            {
                Response.StatusCode = 400;
                return Json("NO_CONSULTA_IN_LAST_DAYS");
            }

            if (agendaUpdated.Id == -2)
            {
                Response.StatusCode = 400;
                return Json("EXISTS_CONSULTA_IN_DATE");
            }

            return Json(agendaUpdated);
        }

        [HttpPost]
        public void Delete(long id)
        {
            agendaService.delete(id);
        }
    }
}