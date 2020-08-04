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
using RentCarSystem.UI.Consultas;
using RentCarSystem.UI.Registros;

namespace RentCarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

    

        private void UsuarioMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rUsuarios rUsuarios = new rUsuarios();
            rUsuarios.Show();

        }

        private void ClienteMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rClientes rClientes = new rClientes();
            rClientes.Show();
                

        }

        private void EmpleadoMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rEmpleados rEmpleados = new rEmpleados();
            rEmpleados.Show();
        }

        private void VehiculoMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rVehiculos rVehiculos = new rVehiculos();
            rVehiculos.Show();
        }

        private void RentaMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rRentas rRentas = new rRentas();
            rRentas.Show();
        }

        private void MantenimientoMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rMantenimientos rMantenimientos = new rMantenimientos();
            rMantenimientos.Show();
        }

        private void ConsultaClientesMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            cClientes  cClientes = new cClientes();
            cClientes.Show();

        }

        private void MarcaMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            rMarcas rMarcas = new rMarcas();
            rMarcas.Show();
        }
    }
}
