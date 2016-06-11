using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Usuario
    {
        public long Id { get; set; }

        [Required]
        public String Login { get; set; }

        [Required]
        public String Senha { get; set; }

        [Compare("Senha")]
        public virtual String SenhaVerificador { get; set; }

        public String Role { get; set; }
    }
}