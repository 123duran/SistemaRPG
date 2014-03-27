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
using SistemaRPG.localhost;
namespace SistemaRPG
{
    /// <summary>
    /// Interaction logic for WRolarWeb.xaml
    /// </summary>
    public partial class WRolarWeb : Window
    {
        public WRolarWeb()
        {
            InitializeComponent();
        }

        private void btnRolarDado_Click(object sender, RoutedEventArgs e)
        {
            localhost.ServiceSoapClient ws = new localhost.ServiceSoapClient();
            MessageBox.Show("Valor: " + ws.RolarDadosWeb().ToString());
        }
    }
}
