using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Especialidade
    {
        public long Id { get; set; }

        [Required]
        public String Nome { get; set; }

        public List<Medico> Medicos { get; set; }
    }
}