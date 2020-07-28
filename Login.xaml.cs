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

namespace RentCarSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        Usuarios usuario = new Usuarios();
        MainWindow Principal = new MainWindow();
        public Login()
        {
            InitializeComponent();
        
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void IniciarSeccionButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = UsuariosBLL.Autenticar(NombreUsuarioTextBox.Text, PasswordPasswordBox.Password);

            if(paso)
            {
                this.Close();
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña son incorrectas", "Error!");
                PasswordPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
