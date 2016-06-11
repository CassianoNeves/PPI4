using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Medico
    {
        public long Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public int Crm { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public Especialidade Especialidade { get; set; }
        
    }
}