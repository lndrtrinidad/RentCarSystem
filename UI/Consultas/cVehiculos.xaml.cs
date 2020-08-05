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

namespace RentCarSystem.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cVehiculos.xaml
    /// </summary>
    public partial class cVehiculos : Window
    {
        public cVehiculos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Vehiculos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            listado = VehiculosBLL.GetList(l => l.VehiculoId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 1:
                        try
                        {
                            listado = VehiculosBLL.GetList(l => l.MarcaId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 2:
                        try
                        {
                            listado = VehiculosBLL.GetList(l => l.Modelo.Contains(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 3:
                        try
                        {
                            listado = VehiculosBLL.GetList(l => l.Ano == Utilidades.ToInt(CriterioTextBox.Text)); 
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;

                    case 5:
                        try
                        {
                            long id = long.Parse(CriterioTextBox.Text);
                            listado = VehiculosBLL.GetList(l => l.Costo == id);
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Debes ingresar un Critero valido para aplicar este filtro.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                }
            }
            else
            {
                
                listado = VehiculosBLL.GetList(c => true);
            }

            if (DesdeDatePicker.SelectedDate != null)
                listado = VehiculosBLL.GetList(c => c.FechaIngreso.Date >= DesdeDatePicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = VehiculosBLL.GetList(c => c.FechaIngreso.Date <= HastaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
    
}
