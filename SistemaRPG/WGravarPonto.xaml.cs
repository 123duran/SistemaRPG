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
    /// Interaction logic for WGravarPonto.xaml
    /// </summary>
    public partial class WGravarPonto : Window
    {
        public WGravarPonto()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (validaTxt(txtInfo.Text))
            {
                MessageBox.Show("Preencha as informações antes de gravar!");
            }
            else
            {
                //Cast para passar o conteúdo atual da combo para um objeto que será usado para setar uma variável
                Aventura a = (Aventura)cmbAventura.SelectedItem;
                gravarPonto(a.NomeAventura,a.CodAventura,txtInfo.Text);
                this.Close();
            }
        }



        public bool validaTxt (string texto)
        {
            if (texto.Length == 0)
                return true;
            else
                return false;
        }

        public void gravarPonto(string Desc_aventura, int codAven,string texto)
        {


        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            AventuraDAO avDao = AventuraDAO.getInstance();
            cmbAventura.ItemsSource = avDao.populaAventura();
        }
    }
}
