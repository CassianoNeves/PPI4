using projeto_MVC.Dominio;
using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Services
{
    public class LoginService
    {
        Contexto contexto = new Contexto();

        public Usuario login(LoginViewModel loginViewModel)
        {
            List<Usuario> usuarios = contexto.Usuario.Where(u => u.Login == loginViewModel.Login && u.Senha == loginViewModel.Senha).ToList();

            if (usuarios != null && usuarios.Count > 0) {
                return usuarios.First();
            }

            return null;
        }

    }
}