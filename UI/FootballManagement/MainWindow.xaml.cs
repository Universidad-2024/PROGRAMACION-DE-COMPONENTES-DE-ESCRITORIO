using BusinessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballManagement
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EquipoRepository _equipoRepository;

        public MainWindow()
        {
            InitializeComponent();
            _equipoRepository = new EquipoRepository();
            CargarEquipos();
        }

        private void CargarEquipos()
        {
            var equipos = _equipoRepository.GetAllEquipos();
            EquiposDataGrid.ItemsSource = equipos;
            MostrarTotalesEquipos();
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            var agregarModificarWindow = new AgregarModificarEquipoWindow();
            if (agregarModificarWindow.ShowDialog() == true)
            {
                CargarEquipos();
            }
        }

        private void MostrarTotalesEquipos()
        {
            int totalMasculinos = _equipoRepository.ObtenerCantidadEquiposMasculinos();
            int totalFemeninos = _equipoRepository.ObtenerCantidadEquiposFemeninos();

            TotalMasculinosTextBlock.Text = totalMasculinos.ToString();
            TotalFemeninosTextBlock.Text = totalFemeninos.ToString();
        }



        private void Modificar_Click(object sender, RoutedEventArgs e)
        {
            var equipoSeleccionado = EquiposDataGrid.SelectedItem as Equipo;
            if (equipoSeleccionado != null)
            {
                var agregarModificarWindow = new AgregarModificarEquipoWindow(equipoSeleccionado);
                if (agregarModificarWindow.ShowDialog() == true)
                {
                    CargarEquipos();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo para modificar.");
            }
        }

        private void VerDetalles_Click(object sender, RoutedEventArgs e)
        {
            var equipoSeleccionado = EquiposDataGrid.SelectedItem as Equipo;
            if (equipoSeleccionado != null)
            {
                // Crear la ventana de detalles y pasarle el equipo seleccionado
                var detalleEquipoWindow = new DetalleEquipoWindow(equipoSeleccionado);
                detalleEquipoWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo para ver los detalles.");
            }
        }


        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            Equipo equipoSeleccionado = EquiposDataGrid.SelectedItem as Equipo;
            if (equipoSeleccionado != null)
            {
                var resultado = MessageBox.Show("¿Está seguro de eliminar este equipo?", "Confirmar Eliminación", MessageBoxButton.YesNo);
                if (resultado == MessageBoxResult.Yes)
                {
                    if (_equipoRepository.DeleteEquipo(equipoSeleccionado.EquipoId))
                    {
                        MessageBox.Show("Equipo eliminado correctamente.");
                        CargarEquipos();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al eliminar el equipo.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un equipo para eliminar.");
            }
        }
    }
}
