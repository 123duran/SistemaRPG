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
    /// Interaction logic for WEnviarDados.xaml
    /// </summary>
    public partial class WEnviarDados : Window
    {
        public WEnviarDados()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            AventuraDAO avDao = AventuraDAO.getInstance();
            CadastroDAO cadDao = CadastroDAO.getInstance();


            /*List<Aventura> ab = avDao.populaAventura();
            foreach (Aventura xa in ab)
            {
                Console.WriteLine(xa.NomeAventura);
                Console.WriteLine(xa.CodAventura);
            }*/

            cmbAventura.ItemsSource = avDao.populaAventura();

              Aventura a = (Aventura)cmbAventura.SelectedItem;
              //cmbJogador.ItemsSource = cadDao.SelecionaPersonagemEspecifico(a.NomeAventura);
        }

        private void cmbAventura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Aventura a = (Aventura)cmbAventura.SelectedItem;
            CadastroDAO cadDao = CadastroDAO.getInstance();
             List <int> listajog= cadDao.SelecionaPersonagemEspecifico(a.NomeAventura);

             cmbJogador.ItemsSource = cadDao.SelecionaPersonagemPorCodPer(listajog);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AventuraDadoDAO dao = new AventuraDadoDAO();
               Aventura a = (Aventura)cmbAventura.SelectedItem;
            Personagem p = (Personagem)cmbJogador.SelectedItem;
            //cast que transforma o conteúdo da combobox em uma string
            string d = ((ComboBoxItem)cmbDados.SelectedItem).Content.ToString();

         //int d = Convert.ToInt32( cmbDados.Items.CurrentItem);
         

            try
            {
               dao.gravarDado(a.CodAventura, p.CodPer, Convert.ToInt32(d));
               MessageBox.Show("Enviado(s) " + d + " dados para o personagem " + p.NomePer);
            }
            catch (Exception error) 
            {
                MessageBox.Show(error.ToString());
            }
            }



    }
}
