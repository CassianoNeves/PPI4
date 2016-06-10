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
            Especialidade especialidade = contexto.Especialidade.Find(medico.Especialidade.Id);

            medico.Especialidade = especialidade;

            contexto.Medico.Add(medico);
            contexto.SaveChanges();
        }

        public void edit(Medico medico)
        {
            Especialidade especialidade = contexto.Especialidade.Find(medico.Especialidade.Id);
            medico.Especialidade = especialidade;

            contexto.Entry<Medico>(medico).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void delete(long id) 
        {
            Medico medico = contexto.Medico.Find(id);

            contexto.Medico.Remove(medico);
            contexto.SaveChanges();
        }

        public List<Medico> getAll()
        {
            return contexto.Medico.Include("Especialidade").ToList();
        }

        public Medico findById(long id)
        {
            return contexto.Medico.Include("Especialidade").Where(m => m.Id == id).FirstOrDefault();
        }
    }
}