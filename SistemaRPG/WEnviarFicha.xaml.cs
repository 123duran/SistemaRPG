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
    /// Interaction logic for WEnviarFicha.xaml
    /// </summary>
    public partial class WEnviarFicha : Window
    {
        public WEnviarFicha()
        {
            InitializeComponent();
        }

        private void btProcurar(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".xml";
            dlg.Filter = "Fichas em xml (*.xml)|*.xml";


            // Mostra o OpenFileDialog chamando método ShowDialog
            Nullable<bool> result = dlg.ShowDialog();

            //Pega o nome do arquivo selecionado e mostra em uma textbox

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                txtCaminho.Text = filename;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Método para passar o caminho do textbox para o form de enviar email
            WEnviarEmail email = new WEnviarEmail();
            email.path = txtCaminho.Text;
            email.ShowDialog();
        }
    }
}
