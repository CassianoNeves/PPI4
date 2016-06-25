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
        private static String[] tiposDeConsulta = {
                                                     "Consulta",
                                                     "Reconsulta",
                                                     "Consulta de Rotina"
                                                 };

        Contexto contexto = new Contexto();

        public FiltrosAgenda getFiltros()
        {
            FiltrosAgenda filtros = new FiltrosAgenda();

            filtros.Medicos = medicoService.getAll();
            filtros.Pacientes = pacienteService.getAll();
            filtros.tiposDeConsulta = tiposDeConsulta;

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

            List<Agenda> agendamentos = new List<Agenda>();

            var where = contexto.Agenda.Include("Paciente").Include("Medico").Where(a => a.Medico.Id == filtros.IdMedico);

            if (filtros.IdPaciente > 0) {
                where = where.Where(a => a.Paciente.Id == filtros.IdPaciente);
            }

            agendamentos = where.ToList();

            result.Agendamentos = new List<Agenda>();

            foreach (Agenda a in agendamentos)
            {
                Agenda agenda = new Agenda();

                agenda.Id = a.Id;
                agenda.Paciente = a.Paciente;
                agenda.DataDaConsulta = a.DataDaConsulta;
                agenda.TipoConsulta = a.TipoConsulta;

                result.Agendamentos.Add(agenda);
            }

            return result;
        }

        public Agenda create(Agenda agenda)
        {
            if (!isValidOperation(agenda))
            {
                return agenda;
            }

            agenda.Paciente = contexto.Paciente.Find(agenda.IdPaciente);
            agenda.Medico = contexto.Medico.Find(agenda.IdMedico);

            contexto.Agenda.Add(agenda);
            contexto.SaveChanges();
            return agenda;
        }

        public Agenda update(Agenda agenda)
        {
            if (!isValidOperation(agenda)) 
            {
                return agenda;
            }

            agenda.Paciente = contexto.Paciente.Find(agenda.IdPaciente);
            agenda.Medico = contexto.Medico.Find(agenda.IdMedico);

            contexto.Entry<Agenda>(agenda).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
            return agenda;
        }

        public void delete(long id)
        {
            Agenda agenda = contexto.Agenda.Find(id);
            contexto.Agenda.Remove(agenda);
            contexto.SaveChanges();
        }

        private Boolean isValidOperation(Agenda agenda)
        {
            if (agenda.TipoConsulta == "Reconsulta")
            {
                DateTime dataLimit = DateTime.Now.AddDays(-30);

                List<Agenda> consutas = contexto.Agenda.Where(a => 
                    (a.Paciente.Id == agenda.IdPaciente) && 
                    (a.DataDaConsulta >= dataLimit) && 
                    (a.DataDaConsulta <= agenda.DataDaConsulta) 
                    && a.TipoConsulta.Equals("Consulta") && 
                    (a.Id != agenda.Id) &&
                    (a.Medico.Id == agenda.IdMedico)
                    ).ToList();

                if (consutas == null || consutas.Count == 0)
                {
                    agenda.Id = -1;
                    return false;
                }
            }

            return true;
        }
    }
}