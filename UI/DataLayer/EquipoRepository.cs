using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EquipoRepository: IEquipoRepository
    {
        private readonly PCEEntities _context;

        public EquipoRepository()
        {
            _context = new PCEEntities();
        }

        public bool SaveEquipo(string nombreEquipo, int cantidadJugadores, string nombreDT, string tipoEquipo, string capitanEquipo, bool tieneSub21)
        {
            var result = _context.spEquipoSave(nombreEquipo, cantidadJugadores, nombreDT, tipoEquipo, capitanEquipo, tieneSub21);
            return result > 0;
        }

        public bool UpdateEquipo(int equipoId, string nombreEquipo, int cantidadJugadores, string nombreDT, string tipoEquipo, string capitanEquipo, bool tieneSub21)
        {
            var result = _context.spEquipoUpdateById(equipoId, nombreEquipo, cantidadJugadores, nombreDT, tipoEquipo, capitanEquipo, tieneSub21);
            return result > 0;
        }

        public bool DeleteEquipo(int equipoId)
        {
            var result = _context.spEquipoDeleteById(equipoId);
            return result > 0;
        }

        public List<Equipo> GetAllEquipos()
        {
            return _context.Equipo.ToList();
        }

        public int ObtenerCantidadEquiposFemeninos()
        {
            var result = _context.spObtenerCantidadEquiposFemeninos().FirstOrDefault();
            Console.WriteLine(result);
            return result.HasValue ? result.Value : 0;

        }

        public int ObtenerCantidadEquiposMasculinos()
        {
            var result = _context.spObtenerCantidadEquiposMasculinos().FirstOrDefault();
            return result.HasValue ? result.Value : 0;
        }
    }
}
