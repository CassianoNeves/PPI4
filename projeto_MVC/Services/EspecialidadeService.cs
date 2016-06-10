using projeto_MVC.Dominio;
using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Services
{
    public class EspecialidadeService
    {
        Contexto contexto = new Contexto();

        public void create(Especialidade especialidade)
        {
            contexto.Especialidade.Add(especialidade);
            contexto.SaveChanges();
        }

        public void edit(Especialidade especialidade)
        {
            contexto.Especialidade.Add(especialidade);
            contexto.SaveChanges();
        }

        public void delete(long id)
        {
            Especialidade especialidade = contexto.Especialidade.Find(id);
            contexto.Especialidade.Remove(especialidade);
            contexto.SaveChanges();
        }

        public Especialidade findById(long id)
        {
            return contexto.Especialidade.Find(id);
        }

        public List<Especialidade> getAll()
        {
            return contexto.Especialidade.ToList();
        }
    }
}