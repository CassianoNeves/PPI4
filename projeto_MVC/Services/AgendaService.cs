using projeto_MVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projeto_MVC.Services
{
    public class AgendaService
    {
        private MedicoService medicoService = new MedicoService();
        private PacienteService pacienteService = new PacienteService();

        public FiltrosAgenda getFiltros()
        {
            FiltrosAgenda filtros = new FiltrosAgenda();

            filtros.medicos = medicoService.getAll();
            filtros.pacientes = pacienteService.getAll();

            return filtros;
        }

    }
}