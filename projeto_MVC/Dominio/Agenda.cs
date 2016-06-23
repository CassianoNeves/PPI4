using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Agenda
    {
        public long Id { get; set; }

        [Required]
        public Medico Medico { get; set; }

        [Required]
        public Paciente Paciente { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataDaConsulta { get; set; }

        [Required]
        public String TipoConsulta { get; set; }

        [NotMapped]
        public virtual long IdMedico { get; set; }

        [NotMapped]
        public virtual long IdPaciente { get; set; }
    }
}