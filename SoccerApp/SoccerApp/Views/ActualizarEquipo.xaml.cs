using SoccerApp.Interfaces;
using SoccerApp.Models;
using SoccerApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoccerApp.Views
{
    /// <summary>
    /// Lógica de interacción para ActualizarEquipo.xaml
    /// </summary>
    public partial class ActualizarEquipo : UserControl
    {

        private Equipo? _equipo;
        private readonly EquipoService _equipoService;
        public ActualizarEquipo(IEquipoRepository equipoRepository)
        {
            InitializeComponent();
            _equipoService = new EquipoService(equipoRepository);
        }

        private void CantidadJugadoresTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public void SetEquipo(Equipo equipo)
        {
            _equipo = equipo;
  
            NombreEquipoTextBox.Text = _equipo.NombreEquipo;
            CantidadJugadoresTextBox.Text = _equipo.CantidadJugadores.ToString();
            NombreDTTextBox.Text = _equipo.NombreDT;
            CapitanEquipoTextBox.Text = _equipo.CapitanEquipo;
            TipoEquipoTextBox.Text = _equipo.TipoEquipo;
            TieneSub21CheckBox.IsChecked = _equipo.TieneSub21;
        }

        private void GuardarCambios_Click(object sender, RoutedEventArgs e)
        {
            string nombreEquipo = NombreEquipoTextBox.Text;
            string cantidadJugadores = CantidadJugadoresTextBox.Text;
            string nombreDirectorTecnico = NombreDTTextBox.Text;
            string capitanEquipo = CapitanEquipoTextBox.Text;
            string tipoEquipo = TipoEquipoTextBox.Text;
            if (
                string.IsNullOrWhiteSpace(nombreEquipo) ||
                string.IsNullOrWhiteSpace(nombreDirectorTecnico) ||
                string.IsNullOrWhiteSpace(capitanEquipo) ||
                string.IsNullOrWhiteSpace(tipoEquipo) ||
                !int.TryParse(cantidadJugadores, out _))
            {
                MessageBox.Show("Por favor, Complete los campos.");
                return;
            }

            if (_equipo != null)
            {
                _equipo.NombreEquipo = nombreEquipo;
                _equipo.CantidadJugadores = int.Parse(cantidadJugadores);
                _equipo.NombreDT = nombreDirectorTecnico;
                _equipo.CapitanEquipo = capitanEquipo;
                _equipo.TipoEquipo = tipoEquipo;
                _equipo.TieneSub21 = TieneSub21CheckBox.IsChecked ?? false;

                _equipoService.ActualizarEquipo(_equipo);

                MessageBox.Show("Equipo actualizado correctamente.");
            }


        }
    }
}
