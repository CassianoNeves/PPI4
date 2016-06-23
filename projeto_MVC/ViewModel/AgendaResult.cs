using projeto_MVC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.ViewModel
{
    public class AgendaResult
    {
        public String HrInicio { get; set; }
        public String HrFim { get; set; }
        public String DuracaoConsulta { get; set; }
        public List<int> diasDaSemana { get; set; }
        public List<Agenda> Agendamentos { get; set; }
    }
}