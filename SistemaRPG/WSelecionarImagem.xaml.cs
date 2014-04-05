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
    /// Interaction logic for WSelecionarImagem.xaml
    /// </summary>
    public partial class WSelecionarImagem : Window
    {
        public WSelecionarImagem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método para pegar o valor da imagem selecionada 
        /// </summary>
        public int img;
        public int getImagem
        {
            get { return img; }
            set { img = value; }
        }

        private void btnSelecionar(object sender, RoutedEventArgs e)
        {
            if (rdHuman.IsChecked == true)
            {
                img = 1;
            }
            else if (rdElfo.IsChecked == true)
            {
                img = 2;
            }
            else if (rdBarbaro.IsChecked == true)
            {
                img = 3;
            }
            else if (rdLadino.IsChecked == true)
            {
                img = 4;
            }
            else if (rdAnao.IsChecked == true)
            {
                img = 5;
            }
            else if (rdOrc.IsChecked == true)
            {
                img = 6;
            }
            else if (rdPaladino.IsChecked == true)
            {
                img = 7;
            }
            else if (rdFeiticeiro.IsChecked == true)
            {
                img = 8;
            }
            else
            {
                img = 0;
            }
            this.Hide();
            }

    }
}
