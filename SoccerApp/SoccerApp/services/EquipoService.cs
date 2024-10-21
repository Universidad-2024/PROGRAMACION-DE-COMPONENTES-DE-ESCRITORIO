using SoccerApp.Interfaces;
using SoccerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.services
{
    internal class EquipoService
    {
        private readonly IEquipoRepository _equipoRepository;

        public EquipoService(IEquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
        }

        public void ActualizarEquipo(Equipo equipo)
        {
            _equipoRepository.ActualizarEquipo(equipo);
        }

        public void AgregarEquipo(Equipo equipo)
        {
            _equipoRepository.AgregarEquipo(equipo);
        }

        public void EliminarEquipo(Equipo equipo)
        {
            _equipoRepository.EliminarEquipo(equipo);
        }

        public ObservableCollection<Equipo> ObtenerEquipos()
        {
            return _equipoRepository.ObtenerEquipos();

        }
    }
}
