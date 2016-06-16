using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Dominio
{
    public class DayOfWork
    {
        public long Id { get; set; }

        public Medico Medico { get; set; }

        public int DayOfWeek { get; set; }
    }
}