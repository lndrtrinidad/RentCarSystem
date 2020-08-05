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

            if (VehiculoIdTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Vehiculo Id) está vacío.\n\nAsigne un Id al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                VehiculoIdTextBox.Text = "0";
                VehiculoIdTextBox.Focus();
                VehiculoIdTextBox.SelectAll();
                return;
            }
            if (MarcaComboBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Marca) está vacío.\n\nPorfavor, Seleccione La Marca del Vehiculo a Crear.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                MarcaComboBox.IsDropDownOpen = true;
                return;
            }
            
            if (MatriculaTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Matricula) está vacío.\n\nAsigne una Matricula al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                MatriculaTextBox.Text = "0";
                MatriculaTextBox.Focus();
                MatriculaTextBox.SelectAll();
                return;
            }
            
            
            if (ModeloTextbox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Modelo) está vacío.\n\nAsigne un Modelo al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ModeloTextbox.Clear();
                ModeloTextbox.Focus();
                return;
            }
            
            if (DescripcionTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Descripciòn) está vacío.\n\nAsigne un comentario al vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Clear();
                DescripcionTextBox.Focus();
                return;
            }
            
            if (VINTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (VIN Number) está vacío.\n\nAsigne un VIN al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                VINTextBox.Text = "0";
                VINTextBox.Focus();
                VINTextBox.SelectAll();
                return;
            }
            if (PlacaTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo(Placa) esta vacio .\n\nAsigne una placa al vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PlacaTextBox.Focus();
                return;
            }
           
            
            if (AnoTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El campo (Año) esta vacio .\n\nAsigne un Año al vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                AnoTextBox.Focus();
                return;
            }
            
            //———————————————————————————————[ Direccion ]———————————————————————————————
            if (CostoTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Costo) está vacío.\n\nAsigne un costo al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CostoTextBox.Clear();
                CostoTextBox.Focus();
                return;
            }
            //———————————————————————————————[ Correo ]———————————————————————————————
            if (PrecioPorDiaTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Precio Por Dia) está vacío.\n\nAsigne un Precio al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioPorDiaTextBox.Clear();
                PrecioPorDiaTextBox.Focus();
                return;
            }
            //———————————————————————————————————————————————————————[ VALIDAR SI ESTA VACIO - FIN ]———————————————————————————————————————————————————————
            
        

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
