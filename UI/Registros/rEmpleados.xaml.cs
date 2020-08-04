using RentCarSystem.BLL;
using RentCarSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RentCarSystem.UI.Registros
{
    /// <summary>
    /// Interaction logic for rEmpleados.xaml
    /// </summary>
    public partial class rEmpleados : Window
    {
        private Empleados Empleados = new Empleados();
        public rEmpleados()
        {
            InitializeComponent();
        }

        private void EmpleadoIdTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Limpiar()
        {
            this.Empleados = new Empleados();
            this.DataContext = Empleados;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (EmpleadoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var clientes = EmpleadosBLL.Buscar(Utilidades.ToInt(EmpleadoIdTextBox.Text));

            if (clientes != null)
                this.Empleados = clientes;
            else
                this.Empleados = new Empleados();

            this.DataContext = this.Empleados;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = EmpleadosBLL.Guardar(Empleados);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado correctamente!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmpleadosBLL.Eliminar(Utilidades.ToInt(EmpleadoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Fallo",
                   MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
