using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Disco
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public Artista Artista { get; set; }
    }
}