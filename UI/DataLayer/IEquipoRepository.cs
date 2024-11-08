using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal interface IEquipoRepository
    {
        bool SaveEquipo(string nombreEquipo, int cantidadJugadores, string nombreDT, string tipoEquipo, string capitanEquipo, bool tieneSub21);
        bool UpdateEquipo(int equipoId, string nombreEquipo, int cantidadJugadores, string nombreDT, string tipoEquipo, string capitanEquipo, bool tieneSub21);
        bool DeleteEquipo(int equipoId);
        List<Equipo> GetAllEquipos();
    }
}
