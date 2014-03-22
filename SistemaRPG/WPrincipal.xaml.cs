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
    /// Interaction logic for WPrincipal.xaml
    /// </summary>
    public partial class WPrincipal : Window
    {
        
        public WPrincipal()
        {
            InitializeComponent();
        }

        private void mnCadastrarFicha(object sender, RoutedEventArgs e) {
            MainWindow frm = new MainWindow();
            frm.ShowDialog();
        }

        private void mnImportarFicha(object sender, RoutedEventArgs e)
        {
            WImportaFicha frm = new WImportaFicha();
            frm.ShowDialog();
        }

        private void mnEnviarFicha(object sender, RoutedEventArgs e)
        {
            WEnviarFicha frm = new WEnviarFicha();
            frm.ShowDialog();
        }

       

        private void mnRolarLocal(object sender, RoutedEventArgs e)
        {
            WRolarLocal frm = new WRolarLocal();
            frm.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            WRolarLocal frm = new WRolarLocal();
            frm.Show();
        }
    }
}
