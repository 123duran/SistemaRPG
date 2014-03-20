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
    /// Interaction logic for WEnviarEmail.xaml
    /// </summary>
    public partial class WEnviarEmail : Window
    {
        public WEnviarEmail()
        {
            InitializeComponent();
        }



        public String path 
        {
            get { return this.txtEnviarEmail.Text; }
            set { this.txtEnviarEmail.Text = value; }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
