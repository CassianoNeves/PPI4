using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("conexao")
        {
            //this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<DayOfWork> DayOfWork { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
    }
}