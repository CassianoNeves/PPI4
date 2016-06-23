using projeto_MVC.Dominio;
using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Services
{
    public class MedicoService
    {
        private Contexto contexto = new Contexto();

        public void create(Medico medico)
        {
            medico.Especialidades = contexto.Especialidade.Where(x => medico.IdEspecialidades.Contains(x.Id)).ToList();

            contexto.Entry<Medico>(medico).State = System.Data.Entity.EntityState.Added;

            foreach (Especialidade e in medico.Especialidades)
            {
                contexto.Entry<Especialidade>(e).State = System.Data.Entity.EntityState.Unchanged;
            }

            List<DayOfWork> days = new List<DayOfWork>();

            foreach (int day in medico.IdDayOfWorks)
            {
                DayOfWork dayOfWork = new DayOfWork();

                dayOfWork.Medico = medico;
                dayOfWork.DayOfWeek = day;
                days.Add(dayOfWork);
            }

            contexto.DayOfWork.AddRange(days);
            contexto.SaveChanges();
        }

        public void edit(Medico medico)
        {
            medico.Especialidades = contexto.Especialidade.Where(x => medico.IdEspecialidades.Contains(x.Id)).ToList();

            contexto.Entry<Medico>(medico).State = System.Data.Entity.EntityState.Modified;

            foreach (Especialidade e in medico.Especialidades)
            {
                contexto.Entry<Especialidade>(e).State = System.Data.Entity.EntityState.Modified;
            }

            List<DayOfWork> days = new List<DayOfWork>();

            foreach (int day in medico.IdDayOfWorks)
            {
                DayOfWork dayOfWork = new DayOfWork();

                dayOfWork.Medico = medico;
                dayOfWork.DayOfWeek = day;
                days.Add(dayOfWork);
            }

            List<DayOfWork> dayOfWorkOlds = contexto.DayOfWork.Where(d => d.Medico.Id.Equals(medico.Id)).ToList();

            contexto.DayOfWork.RemoveRange(dayOfWorkOlds);
            contexto.DayOfWork.AddRange(days);
            contexto.SaveChanges();
        }

        public void delete(long id) 
        {
            Medico medico = contexto.Medico.Include("Especialidades").Include("DayOfWork").Where(m => m.Id == id).First();

            contexto.DayOfWork.RemoveRange(medico.DayOfWork);
            contexto.Medico.Remove(medico);
            contexto.SaveChanges();
        }

        public List<Medico> getAll()
        {
            List<Medico> medicos = contexto.Medico.Include("Especialidades").Include("DayOfWork").ToList();
            return medicos;
        }

        public Medico findById(long id)
        {
            Medico medico = contexto.Medico.Include("Especialidades").Include("DayOfWork").Where(m => m.Id == id).FirstOrDefault();
            List<long> idEspecialidades = new List<long>();
            List<long> idDayOfWorks = new List<long>();

            foreach (Especialidade e in medico.Especialidades)
            {
                idEspecialidades.Add(e.Id);
            }

            foreach (DayOfWork d in medico.DayOfWork)
            {
                idDayOfWorks.Add(d.DayOfWeek);
            }

            medico.IdDayOfWorks = idDayOfWorks;
            medico.IdEspecialidades = idEspecialidades;

            return medico;
        }
    }
}