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
            : this() // Llama al constructor sin parámetros primero
        {
            _equipoExistente = equipo;
            // Llenar los campos con los datos del equipo existente
            NombreEquipoTextBox.Text = equipo.NombreEquipo;
            CantidadJugadoresTextBox.Text = equipo.CantidadJugadores.ToString();
            NombreDTTextBox.Text = equipo.NombreDT;
            TipoEquipoComboBox.SelectedItem = equipo.TipoEquipo; // Asumiendo que TipoEquipo es un texto
            CapitanEquipoTextBox.Text = equipo.CapitanEquipo;
            TieneSub21CheckBox.IsChecked = equipo.TieneSub21;
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // Obtener los valores de los controles de la UI
            string nombreEquipo = NombreEquipoTextBox.Text;
            int cantidadJugadores;
            bool cantidadValida = int.TryParse(CantidadJugadoresTextBox.Text, out cantidadJugadores); // Validar que sea un número

            if (!cantidadValida)
            {
                MessageBox.Show("La cantidad de jugadores debe ser un número válido.");
                return;
            }

            string nombreDT = NombreDTTextBox.Text;
            string tipoEquipo = (TipoEquipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string capitanEquipo = CapitanEquipoTextBox.Text;
            bool tieneSub21 = TieneSub21CheckBox.IsChecked ?? false;

            // Llamar al método SaveEquipo de EquipoRepository
            var equipoRepository = new EquipoRepository();
            bool resultado = equipoRepository.SaveEquipo(nombreEquipo, cantidadJugadores, nombreDT, tipoEquipo, capitanEquipo, tieneSub21);

            if (resultado)
            {
                MessageBox.Show("Equipo guardado correctamente.");
                this.Close(); // Cerrar la ventana si se guardó correctamente
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
