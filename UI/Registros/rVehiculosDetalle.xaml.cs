using RentCarSystem.BLL;
using RentCarSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for rVehiculosDetalle.xaml
    /// </summary>
    /// 
    public partial class rVehiculosDetalle : Window
    {
        
        private Vehiculos vehiculos = new Vehiculos();
        
        public rVehiculosDetalle()
        {
            InitializeComponent();
            this.DataContext = vehiculos;
           
            CaracteristicasComboBox.ItemsSource = CaracteristicasBLL.GetCaracteristicas();
            CaracteristicasComboBox.SelectedValuePath = "CaracteristicasId";
            CaracteristicasComboBox.DisplayMemberPath = "Descripcion";
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
            bool Validado = true;
            if (VehiculoIdTextBox.Text.Length == 0)
            {
                Validado = false;
                MessageBox.Show("Transacción Fallida", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return Validado;
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
                MessageBox.Show($"Esta Devolución no fue encontrado.\n\nAsegúrese que existe o cree una nueva.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                VehiculoIdTextBox.SelectAll();
                VehiculoIdTextBox.Focus();
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (CaracteristicasComboBox.Text == string.Empty)
            {
                MessageBox.Show("El Campo (Caracteristicas) está vacío.\n\nPorfavor, Seleccione el Libro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                CaracteristicasComboBox.IsDropDownOpen = true;
                return;
            }
            if(DescripcionTextBox.Text == String.Empty)
            {
                MessageBox.Show("El Campo (Descripciòn) está vacio.\n\nEscriba la referencia.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
                return;
            }

            var filaDetalle = new VehiculosDetalle
            {
                VehiculoId = this.vehiculos.VehiculoId,
                CaracteristicasId = Convert.ToInt32(CaracteristicasComboBox.SelectedValue.ToString()),
                Descripcion = DescripcionTextBox.Text.ToString(),
             
                caracteristicas = (Caracteristicas)CaracteristicasComboBox.SelectedItem,
             
                
            };

            this.vehiculos.Detalle.Add(filaDetalle);
            Cargar();
            
            CaracteristicasComboBox.SelectedIndex = -1;
            DescripcionTextBox.Clear();

        }

        private void RemoverFilaButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                vehiculos.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = VehiculosBLL.Guardar(this.vehiculos);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado Con Exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            else
                MessageBox.Show("No se pudo Guardad", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VehiculosBLL.Eliminar(Utilidades.ToInt(VehiculoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("El Registro Fue Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            else
                MessageBox.Show("El Registro no pudo se eliminado", "ERROR", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
