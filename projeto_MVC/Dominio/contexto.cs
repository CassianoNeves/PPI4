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

        }

        public DbSet<Artista> Artista { get; set; }
        public DbSet<Disco> Disco { get; set; }
    }
}