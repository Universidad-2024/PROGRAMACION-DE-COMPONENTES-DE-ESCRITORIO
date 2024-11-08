using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EquipoService
    {
        private readonly EquipoRepository _equipoRepository;

        public EquipoService()
        {
            _equipoRepository = new EquipoRepository();
        }

        public bool AgregarEquipo(string nombreEquipo, int cantidadJugadores, string nombreDT, string tipoEquipo, string capitanEquipo, bool tieneSub21)
        {
            return _equipoRepository.SaveEquipo(nombreEquipo, cantidadJugadores, nombreDT, tipoEquipo, capitanEquipo, tieneSub21);
        }

        public bool ModificarEquipo(int equipoId, string nombreEquipo, int cantidadJugadores, string nombreDT, string tipoEquipo, string capitanEquipo, bool tieneSub21)
        {
            return _equipoRepository.UpdateEquipo(equipoId, nombreEquipo, cantidadJugadores, nombreDT, tipoEquipo, capitanEquipo, tieneSub21);
        }

        public bool EliminarEquipo(int equipoId)
        {
            return _equipoRepository.DeleteEquipo(equipoId);
        }

        public List<Equipo> ObtenerEquipos()
        {
            return _equipoRepository.GetAllEquipos();
        }
    }
}
