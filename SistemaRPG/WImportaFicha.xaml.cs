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
    /// Interaction logic for WImportaFicha.xaml
    /// </summary>
    public partial class WImportaFicha : Window
    {
        public WImportaFicha()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.InitialDirectory = @"C:\RPG\";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Fichas xml (*.xml)|*.xml";


            // Mostra o OpenFileDialog chamando método ShowDialog
            Nullable<bool> result = dlg.ShowDialog();

            //Pega o nome do arquivo selecionado e mostra em na textbox

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                txtCaminho.Text = filename;
            }
        }

        private void btnImportar_Click(object sender, RoutedEventArgs e)
        {
            ManipulaXML xml = new ManipulaXML();
            PerBO ficha = null;
            ficha = xml.lerFicha(txtCaminho.Text);
            MessageBox.Show ( "imagem : " +ficha.imgPer.ToString() + "resistencia" + ficha.resPer.ToString() + "pdv: " + ficha.pdvPer.ToString());

        }
    }
}
