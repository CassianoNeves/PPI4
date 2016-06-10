﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class Medico
    {
        public long Id { get; set; }

        public String Nome { get; set; }

        public int Crm { get; set; }

        public String Email { get; set; }

        public Especialidade Especialidade { get; set; }
        
    }
}