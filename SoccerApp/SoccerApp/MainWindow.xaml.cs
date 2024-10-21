using SoccerApp.Interfaces;
using SoccerApp.Models;
using SoccerApp.Repositories;
using SoccerApp.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoccerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEquipoRepository _equipoRepository;
        public delegate void ActualizarEquipoDelegate(Equipo equipo);

        public MainWindow()
        {
            InitializeComponent();
            _equipoRepository = new EquipoRepository();
            this.Title = "Inicio";
        }

        public void ActualizarEquipo_click(Equipo equipo)
        {
            ActualizarEquipo actualizarEquipo = new ActualizarEquipo(_equipoRepository);
            actualizarEquipo.SetEquipo(equipo);
            MainContent.Content = actualizarEquipo;
            this.Title = "Actualizar Equipo";
        }

        private void AcercaDe_Click(object sender, RoutedEventArgs e)
        {
            AcercaDe acercaDeView = new AcercaDe();
            MainContent.Content = acercaDeView;
            this.Title = "Acerca De";
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            {
                AgregarEquipo agregarEquipo = new AgregarEquipo(_equipoRepository);
                MainContent.Content = agregarEquipo;
                this.Title = "Agregar Equipo";
            }
        }        
        private void ListarTodo_Click(object sender, RoutedEventArgs e)
        {
            ListarEquipos equipos = new(_equipoRepository, this);
            MainContent.Content = equipos;
            this.Title = "Listar Todos";
        }
    }
}