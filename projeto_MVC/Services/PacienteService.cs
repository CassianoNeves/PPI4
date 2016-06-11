using projeto_MVC.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Services
{
    public class PacienteService
    {
        private Contexto contexto = new Contexto();

        public void create(Paciente paciente)
        {
            contexto.Paciente.Add(paciente);
            contexto.SaveChanges();
        }

        public void edit(Paciente paciente)
        {
            contexto.Entry<Paciente>(paciente).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();
        }

        public void delete(long id)
        {
            Paciente paciente = contexto.Paciente.Find(id);

            contexto.Paciente.Remove(paciente);
            contexto.SaveChanges();
        }

        public List<Paciente> getAll()
        {
            return contexto.Paciente.ToList();
        }

        public Paciente findById(long id)
        {
            return contexto.Paciente.Find(id);
        }

    }
}