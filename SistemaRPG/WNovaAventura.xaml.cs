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
    /// Interaction logic for WNovaAventura.xaml
    /// </summary>
    public partial class WNovaAventura : Window
    {
        public WNovaAventura()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
          
            //Irá preencher o lbNumAvent com o número da aventura que será iniciada
            lbNumAvent.Content = geraNumAven().ToString();

        }

        /// <summary>
        /// Gera o número da nova aventura
        /// </summary>
        /// <returns>Retorna o número da última aventura + 1</returns>
        private int geraNumAven()
        {
            AventuraDAO dao = new AventuraDAO();
            int ultima = dao.maxAventura();
            return ultima + 1;
        }
    }
}
