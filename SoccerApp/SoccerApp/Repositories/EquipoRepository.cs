using SoccerApp.Interfaces;
using SoccerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SoccerApp.Repositories
{
    internal class EquipoRepository : IEquipoRepository
    {
        private ObservableCollection<Equipo> _equipos = new ObservableCollection<Equipo>();

        public void ActualizarEquipo(Equipo equipo)
        {
            var equipoExistente = _equipos.FirstOrDefault(e => e.NombreEquipo == equipo.NombreEquipo);
            if (equipoExistente != null)
            {
                // Actualiza las propiedades del equipo existente
                equipoExistente.CantidadJugadores = equipo.CantidadJugadores;
                equipoExistente.NombreDT = equipo.NombreDT;
                equipoExistente.CapitanEquipo = equipo.CapitanEquipo;
                equipoExistente.TieneSub21 = equipo.TieneSub21;
            }
            else
            {
                throw new ArgumentException("El equipo no existe.");
            }
        }

        public void AgregarEquipo(Equipo equipo)
        {
            _equipos.Add(equipo);
        }

        public void EliminarEquipo(Equipo equipo)
        {
            ArgumentNullException.ThrowIfNull(equipo);
            _equipos.Remove(equipo);
        }

        public ObservableCollection<Equipo> ObtenerEquipos()
        {
            return _equipos;
        }
    }
}
