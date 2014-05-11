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
using System.Windows.Threading;
using System.Threading;
using System.ComponentModel;
namespace SistemaRPG
{
     
    /// <summary>
    /// Interaction logic for WPrincipal.xaml
    /// </summary>
    public partial class WPrincipal : Window
    {
      //  private BackgroundWorker worker;
        public WPrincipal()
        {
            InitializeComponent();
           // worker = new BackgroundWorker();

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

        private void mnNovaAventura(object sender, RoutedEventArgs e)
        {
            WNovaAventura nova= new WNovaAventura();
            nova.ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            WRolarLocal rola = new WRolarLocal();
            rola.Show();
        }

        private void mnGravarPonto(object sender, RoutedEventArgs e)
        {
            WGravarPonto gravarP = new WGravarPonto();
            gravarP.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            WDadosJogadores dadosJ = new WDadosJogadores();
            dadosJ.ShowDialog();
        }

        private void mnCadastrarJogador(object sender, RoutedEventArgs e)
        {
            WSelecionaJogador cadastro = new WSelecionaJogador();
            cadastro.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            WEnviarMensagem msg = new WEnviarMensagem();
            msg.ShowDialog();
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            WEnviarXp xp = new WEnviarXp();
            xp.ShowDialog();
        }

    }
}
