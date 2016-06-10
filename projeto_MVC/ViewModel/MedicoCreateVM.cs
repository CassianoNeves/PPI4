using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.ViewModel
{
    public class MedicoCreateVM
    {
        public int Id { get; set; }

        public String Nome { get; set; }

        public int Crm { get; set; }

        public String Email { get; set; }

        public int Especialidade { get; set; }
    }
}