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
    /// Interaction logic for WSelecionaJogadorAventura.xaml
    /// </summary>
    public partial class WSelecionaJogadorAventura : Window
    {
        List<Personagem> cadNaoSelec = new List<Personagem>();
        List<Personagem> cadSelec = new List<Personagem>();
        public WSelecionaJogadorAventura()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            AventuraDAO avDao = AventuraDAO.getInstance();
            CadastroDAO cadDao = new CadastroDAO();

            cmbAventura.ItemsSource = avDao.populaAventura();
            //string codAventura = cmbAventura.SelectedItem.ToString();
            //string codAventura = ((ComboBoxItem)cmbAventura.SelectedItem).Content.ToString();
            //// através da combobox preenche a variável que será usada para voltar uma lista de int
            ////tal lista de int irá ser passada para outra função que retorna os jogadores cadastrados naquela aventura
            
            //cadNaoSelec = cadDao.SelecionaPersonagemPorCodPer(cadDao.SelecionaPersonagemEspecifico(codAventura));
            
            //dtJogAven.ItemsSource = cadNaoSelec;
            //dtJogAven.Items.Refresh();
            //dtJogPar.ItemsSource = cadSelec;
            

        }

        //botão de adicionar
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Personagem per = new Personagem();
            per = (Personagem)dtJogAven.SelectedItem;
            AdicionaLista(per);
            dtJogPar.Items.Refresh();
            cadNaoSelec.RemoveAt(dtJogAven.SelectedIndex);
            dtJogAven.Items.Refresh();
           
        }




        private void AdicionaLista(Personagem per)
        {
           cadSelec.Add(per);
        }

        //botão de apagar
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.dtJogAven.SelectedItems.Count > 0) 
            {
                cadNaoSelec.Add(cadSelec[dtJogAven.SelectedIndex]);
                cadSelec.RemoveAt(dtJogAven.SelectedIndex);
             }

            dtJogAven.Items.Refresh();
            dtJogPar.Items.Refresh();

        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            List<PartidaPersonagem> listParPer = new List<PartidaPersonagem>();
            List<int> listaCodPer = new List<int>();
            Aventura a = (Aventura)cmbAventura.SelectedItem;
            int codAv = a.CodAventura;
            gravarPartida(txtNomePar.Text, codAv);

            for (int i = 0; i < cadSelec.Count; i++)
            {
                int codPer = cadSelec[i].CodPer;
                listaCodPer.Add(codPer);
            }

            for (int i = 0; i < cadSelec.Count; i++)
            {
                gravarPartidaPersonagem(listaCodPer);
            }
        }


        public void gravarPartida(string nomePar, int codAv)
        {
            PartidaDAO dao = PartidaDAO.getInstance();
            dao.Gravar(nomePar,codAv);
        }

        public void gravarPartidaPersonagem(List<int> codper)
        {
            PartidaDAO parDao = PartidaDAO.getInstance();
            int codPar = parDao.maxPartida();
            for (int i = 0; i < codper.Count; i++)
            {
                parDao.GravarPerPar(codPar, codper[i]);
            }
        }

        private void cmbAventura_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string codAventura = "";

            Aventura a = (Aventura)cmbAventura.SelectedItem;
            
            // através da combobox preenche a variável que será usada para voltar uma lista de int
            //tal lista de int irá ser passada para outra função que retorna os jogadores cadastrados naquela aventura
            CadastroDAO cadDao = new CadastroDAO();

           // dtJogAven.Items.Clear();
            List<Personagem> listaNaoSelec = new List<Personagem>();

            listaNaoSelec = cadDao.SelecionaPersonagemPorCodPer(cadDao.SelecionaPersonagemEspecifico(a.NomeAventura));

            this.dtJogAven.ItemsSource = listaNaoSelec;

            foreach (Personagem p in listaNaoSelec)
            {
                MessageBox.Show(p.NomePer);
            }
          
            
            dtJogAven.Items.Refresh();
         //   dtJogPar.ItemsSource = cadSelec;
        }

    }
}
