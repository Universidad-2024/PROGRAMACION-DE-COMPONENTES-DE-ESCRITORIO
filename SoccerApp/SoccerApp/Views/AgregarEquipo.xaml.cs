using SoccerApp.Interfaces;
using SoccerApp.Models;
using SoccerApp.services;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para AgregarEquipo.xaml
    /// </summary>
    public partial class AgregarEquipo : UserControl
    {

        private readonly EquipoService _equipoService;
        public AgregarEquipo(IEquipoRepository equipoRepository)
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

        private void Button_Click(object sender, RoutedEventArgs e)
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
                !int.TryParse(cantidadJugadores, out int _cantidadJudarores)){
                MessageBox.Show("Por favor, Complete los campos.");
                return;
            }


            Equipo newEquipo = new()
            {
                CantidadJugadores = int.Parse(cantidadJugadores),
                CapitanEquipo = capitanEquipo,
                NombreDT = nombreDirectorTecnico,
                NombreEquipo = nombreEquipo,
                TipoEquipo = tipoEquipo,
                TieneSub21 = TieneSub21CheckBox.IsChecked ?? true,
            };

            _equipoService.AgregarEquipo(newEquipo);

            MessageBox.Show("Equipo agregado exitosamente.");

            NombreEquipoTextBox.Clear();
            CantidadJugadoresTextBox.Clear();
            NombreDTTextBox.Clear();
            CapitanEquipoTextBox.Clear();
            TipoEquipoTextBox.Clear();
            TieneSub21CheckBox.IsChecked = false;


        }
    }
}
