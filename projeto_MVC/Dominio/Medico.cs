using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public String HrInicio { get; set; }

        [Required]
        public String HrFim { get; set; }

        [Required]
        public String DuracaoConsulta { get; set; }

        public List<DayOfWork> DayOfWork { get; set; }

        public List<Especialidade> Especialidades { get; set; }

        [NotMapped]
        public virtual List<long> IdEspecialidades { get; set; }

        [NotMapped]
        public virtual List<long> IdDayOfWorks { get; set; }
        
    }
}