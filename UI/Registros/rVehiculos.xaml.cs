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
    /// Interaction logic for rVehiculos.xaml
    /// </summary>
    public partial class rVehiculos : Window
    {
        private Vehiculos Vehiculos = new Vehiculos();
        public rVehiculos()
        {
            InitializeComponent();
            this.DataContext = Vehiculos;

            MarcaComboBox.ItemsSource = MarcasBLL.GetMarcas();
            MarcaComboBox.SelectedValuePath = "MarcaId";
            MarcaComboBox.DisplayMemberPath = "Descripcion";
        }

        private void VehiculoIdTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Limpiar()
        {
            this.Vehiculos = new Vehiculos();
            this.DataContext = Vehiculos;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (VehiculoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var vehiculos = VehiculosBLL.Buscar(Utilidades.ToInt(VehiculoIdTextBox.Text));

            if (vehiculos != null)
                this.Vehiculos = vehiculos;
            else
                this.Vehiculos = new Vehiculos();

            this.DataContext = this.Vehiculos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = VehiculosBLL.Guardar(Vehiculos);

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
            if (VehiculosBLL.Eliminar(Utilidades.ToInt(VehiculoIdTextBox.Text)))
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
