using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SistemaRPG
{
    /// <summary>
    /// Interaction logic for WLogin.xaml
    /// </summary>
    public partial class WLogin : Window
    {
        public WLogin()
        {
            InitializeComponent();
        }

        private void btLogin(object sender, RoutedEventArgs e)
        {
            //Método de validação do usuário
            if (txtEmail.Text == "admin" && txtSenha.Text == "00000")
            {
                WPrincipal principal = new WPrincipal();
                principal.ShowDialog();
            }
            else 
            {
                MessageBox.Show("Cadastro Inexistente!");
            }

        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            WCadastro cadastra = new WCadastro();
            cadastra.ShowDialog();
        }
    }
}
