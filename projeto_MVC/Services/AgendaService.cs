using projeto_MVC.Dominio;
using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Services
{
    public class AgendaService
    {
        private MedicoService medicoService = new MedicoService();
        private PacienteService pacienteService = new PacienteService();

        Contexto contexto = new Contexto();

        public FiltrosAgenda getFiltros()
        {
            FiltrosAgenda filtros = new FiltrosAgenda();

            filtros.Medicos = medicoService.getAll();
            filtros.Pacientes = pacienteService.getAll();

            return filtros;
        }

        public AgendaResult buscarAgendamentos(FiltrosAgenda filtros)
        {
            AgendaResult result = new AgendaResult();

            Medico medico = contexto.Medico.Include("DayOfWork").Where(m => m.Id == filtros.IdMedico).FirstOrDefault();

            result.HrInicio = medico.HrInicio;
            result.HrFim = medico.HrFim;
            result.DuracaoConsulta = medico.DuracaoConsulta;
            result.diasDaSemana = new List<int>();

            medico.DayOfWork.ForEach(d => result.diasDaSemana.Add(d.DayOfWeek));

            return result;
        }
    }
}