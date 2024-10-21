using SoccerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerApp.Interfaces
{
    public interface IEquipoRepository
    {
        void AgregarEquipo(Equipo equipo);
        void EliminarEquipo(Equipo equipo);
        void ActualizarEquipo(Equipo equipo);
        ObservableCollection<Equipo> ObtenerEquipos();
    }
}
