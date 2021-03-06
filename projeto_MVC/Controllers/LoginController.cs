﻿using projeto_MVC.Dominio;
using projeto_MVC.Services;
using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace projeto_MVC.Controllers
{
    public class LoginController : Controller
    {
        LoginService loginService = new LoginService();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = loginService.login(loginViewModel);

                if (usuario != null)
                {
                    Session["UsuarioLogado"] = usuario;

                    return RedirectToAction("Index", "Agenda");
                }

                ModelState.AddModelError("LOGIN_INCORRECT", "Login ou senha incorretos.");
                return View("Index", loginViewModel);
            }

            return View("Index", loginViewModel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["UsuarioLogado"] = null;
            return RedirectToAction("Index");
        }
    }
}