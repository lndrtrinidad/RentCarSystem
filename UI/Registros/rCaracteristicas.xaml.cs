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
    /// Interaction logic for rCaracteristicas.xaml
    /// </summary>
    public partial class rCaracteristicas : Window
    {
        private Caracteristicas Carateristicas = new Caracteristicas();
        public rCaracteristicas()
        {
            InitializeComponent();
        }

        private void CaracteristicaIdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Limpiar()
        {
            this.Carateristicas = new Caracteristicas();
            this.DataContext = Carateristicas;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (CaracteristicaIdTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Transaccion Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Caracteristicas = CaracteristicasBLL.Buscar(Utilidades.ToInt(CaracteristicaIdTextBox.Text));

            if (Caracteristicas != null)
                this.Carateristicas = Caracteristicas;
            else
                this.Carateristicas = new Caracteristicas();

            this.DataContext = this.Carateristicas;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CaracteristicasBLL.Guardar(Carateristicas);

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
            if (CaracteristicasBLL.Eliminar(Utilidades.ToInt(CaracteristicaIdTextBox.Text)))
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
