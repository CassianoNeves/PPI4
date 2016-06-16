using projeto_MVC.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projeto_MVC.ViewModel
{
    public class MedicoDto
    {
        public long Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public int Crm { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String HrInicio { get; set; }

        [Required]
        public String HrFim { get; set; }

        [Required]
        public List<long> DayOfWork { get; set; }

        [Required]
        public List<long> Especialidades { get; set; }
    }
}