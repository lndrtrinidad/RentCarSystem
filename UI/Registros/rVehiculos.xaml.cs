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
        private Vehiculos vehiculos = new Vehiculos();
        public rVehiculos()
        {
            InitializeComponent();
            this.DataContext = vehiculos;

            MarcaComboBox.ItemsSource = MarcasBLL.GetMarcas();
            MarcaComboBox.SelectedValuePath = "MarcaId";
            MarcaComboBox.DisplayMemberPath = "Descripcion";

            CaracteristicasComboBox.ItemsSource = CaracteristicasBLL.GetCaracteristicas();
            CaracteristicasComboBox.SelectedValuePath = "CaracteristicasId";
            CaracteristicasComboBox.DisplayMemberPath = "Descripcion";
        }

        private void VehiculoIdTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = vehiculos;
        }

        private void Limpiar()
        {
            this.vehiculos = new Vehiculos();
            this.DataContext = vehiculos;
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
            Vehiculos encontrado = VehiculosBLL.Buscar(vehiculos.VehiculoId);

            if (encontrado != null)
            {
                vehiculos = encontrado;
                Cargar();
            }
            else
            {
                MessageBox.Show("Esta Vehiculo no fue encontrado.\n\nAsegúrese que existe o cree una nueva.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                VehiculoIdTextBox.SelectAll();
                VehiculoIdTextBox.Focus();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {

            if (CaracteristicasComboBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Caracteristicas) está vacío.\n\nPorfavor, Seleccione el Libro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CaracteristicasComboBox.IsDropDownOpen = true;
                return;
            }
            if (ObservacionTextBox.Text == String.Empty)
            {
                MessageBox.Show("El Campo (Observacion) está vacio.\n\nEscriba la referencia.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                ObservacionTextBox.Focus();
                return;
            }

            var filaDetalle = new VehiculosDetalle
            {
                VehiculoId = this.vehiculos.VehiculoId,
                CaracteristicasId = Convert.ToInt32(CaracteristicasComboBox.SelectedValue.ToString()),
                caracteristicas = (Caracteristicas)CaracteristicasComboBox.SelectedItem,
                Observacion = ObservacionTextBox.Text.ToString(),


            };

            this.vehiculos.Detalle.Add(filaDetalle);
            Cargar();

            CaracteristicasComboBox.SelectedIndex = -1;
            ObservacionTextBox.Clear();

        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                vehiculos.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
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
            
            
            if (CostoTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Costo) está vacío.\n\nAsigne un costo al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CostoTextBox.Clear();
                CostoTextBox.Focus();
                return;
            }
            
            if (PrecioPorDiaTextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("El Campo (Precio Por Dia) está vacío.\n\nAsigne un Precio al Vehiculo.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioPorDiaTextBox.Clear();
                PrecioPorDiaTextBox.Focus();
                return;
            }
            
            
        

            var paso = VehiculosBLL.Guardar(vehiculos);

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
