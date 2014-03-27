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
    /// Interaction logic for WPrincipalUsuario.xaml
    /// </summary>
    public partial class WPrincipalUsuario : Window
    {
        public WPrincipalUsuario()
        {
            InitializeComponent();
        }
       

        private void mnCadastrarFicha(object sender, RoutedEventArgs e)
        {
            MainWindow frm = new MainWindow();
            frm.ShowDialog();
             
        }

        private void mnImportarFicha(object sender, RoutedEventArgs e)
        {

        }

        private void mnEnviarFicha(object sender, RoutedEventArgs e)
        {

        }

     
    }
}
