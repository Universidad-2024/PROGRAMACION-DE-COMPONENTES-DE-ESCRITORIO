using DataLayer;
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
using System.Windows.Shapes;

namespace FootballManagement
{
    /// <summary>
    /// Lógica de interacción para AgregarModificarEquipoWindow.xaml
    /// </summary>
    public partial class AgregarModificarEquipoWindow : Window
    {
        private Equipo _equipoExistente;
        public AgregarModificarEquipoWindow()
        {
            InitializeComponent();
        }

        public AgregarModificarEquipoWindow(Equipo equipo)
            : this()
        {
            _equipoExistente = equipo;
            NombreEquipoTextBox.Text = equipo.NombreEquipo;
            CantidadJugadoresTextBox.Text = equipo.CantidadJugadores.ToString();
            NombreDTTextBox.Text = equipo.NombreDT;
            TipoEquipoComboBox.SelectedItem = equipo.TipoEquipo;
            CapitanEquipoTextBox.Text = equipo.CapitanEquipo;
            TieneSub21CheckBox.IsChecked = equipo.TieneSub21;
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            string nombreEquipo = NombreEquipoTextBox.Text;
            bool cantidadValida = int.TryParse(CantidadJugadoresTextBox.Text, out int cantidadJugadores);

            if (!cantidadValida)
            {
                MessageBox.Show("La cantidad de jugadores debe ser un número válido.");
                return;
            }

            string nombreDT = NombreDTTextBox.Text;
            string tipoEquipo = (TipoEquipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string capitanEquipo = CapitanEquipoTextBox.Text;
            bool tieneSub21 = TieneSub21CheckBox.IsChecked ?? false;

            var equipoRepository = new EquipoRepository();
            bool resultado;

            if (_equipoExistente != null)
            {
                _equipoExistente.NombreEquipo = nombreEquipo;
                _equipoExistente.CantidadJugadores = cantidadJugadores;
                _equipoExistente.NombreDT = nombreDT;
                _equipoExistente.TipoEquipo = tipoEquipo;
                _equipoExistente.CapitanEquipo = capitanEquipo;
                _equipoExistente.TieneSub21 = tieneSub21;

                resultado = equipoRepository.UpdateEquipo(
                    _equipoExistente.EquipoId, 
                    _equipoExistente.NombreEquipo, 
                    _equipoExistente.CantidadJugadores,
                    _equipoExistente.NombreDT,
                    _equipoExistente.TipoEquipo,
                    _equipoExistente.CapitanEquipo,
                    _equipoExistente.TieneSub21
                 );

            } else
            {
       
                resultado = equipoRepository.SaveEquipo(
                    nombreEquipo, 
                    cantidadJugadores, 
                    nombreDT, 
                    tipoEquipo, 
                    capitanEquipo, 
                    tieneSub21
                 );
            }

            if (resultado)
            {
                MessageBox.Show("Equipo guardado correctamente.");
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al guardar el equipo.");
            }
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
