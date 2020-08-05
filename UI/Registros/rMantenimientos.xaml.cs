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
    /// Interaction logic for rMantenimientos.xaml
    /// </summary>
    public partial class rMantenimientos : Window
    {
        private Mantenimientos Mantenimientos = new Mantenimientos();
        public rMantenimientos()
        {
            InitializeComponent();

            VehiculoComboBox.ItemsSource = VehiculosBLL.GetVehiculos();
            VehiculoComboBox.SelectedValuePath = "VehiculoId";
            VehiculoComboBox.DisplayMemberPath = "Modelo";
        }

        private void MantenimientoIdTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Limpiar()
        {
            this.Mantenimientos = new Mantenimientos();
            this.DataContext = Mantenimientos;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (MantenimientoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var mantenimientos = MantenimientosBLL.Buscar(Utilidades.ToInt(MantenimientoIdTextBox.Text));

            if (mantenimientos != null)
                this.Mantenimientos = mantenimientos;
            else
                this.Mantenimientos = new Mantenimientos();

            this.DataContext = this.Mantenimientos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = MantenimientosBLL.Guardar(Mantenimientos);

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
            if (MantenimientosBLL.Eliminar(Utilidades.ToInt(MantenimientoIdTextBox.Text)))
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
