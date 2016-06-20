using projeto_MVC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.ViewModel
{
    public class FiltrosAgenda
    {
        public List<Medico> Medicos { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
    }
}