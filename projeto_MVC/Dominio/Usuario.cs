using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Usuario
    {
        public long Id { get; set; }

        public String Login { get; set; }

        public String Senha { get; set; }

        public String Role { get; set; }
    }
}