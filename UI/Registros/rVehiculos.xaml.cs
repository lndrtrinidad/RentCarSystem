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
        public rVehiculos()
        {
            InitializeComponent();
        }

        private void VehiculoIdTextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
