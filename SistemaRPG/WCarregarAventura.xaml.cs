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
    /// Interaction logic for WCarregaAventura.xaml
    /// </summary>
    public partial class WCarregaAventura : Window
    {
        public WCarregaAventura()
        {
            InitializeComponent();
        }

        private void btLogin(object sender, RoutedEventArgs e)
        {
            try
            {

                if (Login(txtAVentura.Text, pbSenha.Password))
                {
                    WSelecionaJogadorAventura aven = new WSelecionaJogadorAventura();
                    aven.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Senha/aventura inválida");
                }
            }
            catch(Exception error) 
            {
                MessageBox.Show(error.ToString());
            }
            
        }

        public bool Login(string aventura, string senha) 
        {
            AventuraDAO dao = new AventuraDAO();
            return dao.LoginAventura(aventura, senha);
        }
    }
}
