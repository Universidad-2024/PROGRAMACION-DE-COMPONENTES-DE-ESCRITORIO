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
    /// Lógica de interacción para DetalleEquipoWindow.xaml
    /// </summary>
    public partial class DetalleEquipoWindow : Window
    {
        public DetalleEquipoWindow(Equipo equipo)
        {
            InitializeComponent();

            NombreEquipoTextBlock.Text = equipo.NombreEquipo;
            CantidadJugadoresTextBlock.Text = equipo.CantidadJugadores.ToString();
            NombreDTTextBlock.Text = equipo.NombreDT;
            TipoEquipoTextBlock.Text = equipo.TipoEquipo;
            CapitanEquipoTextBlock.Text = equipo.CapitanEquipo;
            TieneSub21TextBlock.Text = equipo.TieneSub21 ? "Sí" : "No";
        }
    }
}
