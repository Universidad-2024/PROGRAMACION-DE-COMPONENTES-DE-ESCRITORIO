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
    public partial class ListarEquipos : UserControl
    {

        private readonly EquipoService _equipoService;
        private readonly MainWindow _mainWindow;
        public ListarEquipos(IEquipoRepository equipoRepository, MainWindow mainWindow)
        {
            InitializeComponent();
            _equipoService = new EquipoService(equipoRepository);
            _mainWindow = mainWindow;
            CargarEquipos();
        }

        private void CargarEquipos()
        {
            EquiposItemsControl.ItemsSource = _equipoService.ObtenerEquipos();
        }

        private void EquiposListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void EliminarEquipo_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Tag is Equipo equipoAEliminar)
                {

                    MessageBoxResult resultado = MessageBox.Show($"¿Estás seguro de que deseas eliminar el equipo {equipoAEliminar.NombreEquipo}?",
                        "Confirmar eliminación", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (resultado == MessageBoxResult.Yes)
                    {
                        _equipoService.EliminarEquipo(equipoAEliminar);
                    }
                }
            }
        }

        private void EditarEquipo_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button)
            {
                if (button.Tag is Equipo equipo)
                {
                    MainWindow? mainWindow = Application.Current.MainWindow as MainWindow;

                    mainWindow.ActualizarEquipo_click(equipo);
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el equipo a editar.");
                }
            }
        }
    }
}
