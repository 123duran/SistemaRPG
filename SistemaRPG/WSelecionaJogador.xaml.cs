﻿using System;
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
    /// Interaction logic for WSelecionaJogador.xaml
    /// </summary>
    public partial class WSelecionaJogador : Window
    {
        List<Cadastro> listCad = new List<Cadastro>();
        List<Cadastro> cadNaoSelec = new List<Cadastro>();
        //WLogin wLogin;
        public WSelecionaJogador()
        {        
            InitializeComponent();        
        }

       

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(Cadastro.Cad.CodLogin.ToString()); mostrava  o codlogin do jogador logado
            AventuraDAO avDao = AventuraDAO.getInstance();
            CadastroDAO cadDao = CadastroDAO.getInstance();

            //Populando a comboBox
        //    cmbPartida.ItemsSource = avDao.populaAventura();

            //Populando a dataGrid
            cadNaoSelec = cadDao.SelecionaPersonagem();
            dtJogadores.ItemsSource = cadNaoSelec ;                        
        }

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            //Esse if vai fazer com que só tente passar o objeto para a outra grid caso tenha algo selecionado
            if (this.dtJogadores.SelectedIndex >= 0)
            {
                //Essa é um cast do item para o tipo de objeto cadastrp
                Cadastro cadast = (Cadastro)dtJogadores.SelectedItem;
                //Passa a o objeto obtido como Parâmetro para a função adicionalista
                AdicionaLista(cadast);
                //Adiciona os itens ao ItemSource do dtSelecionados
                dtSelecionados.ItemsSource = listCad;
                //Impede que o usuário adicione novas colunas
                dtSelecionados.CanUserAddRows = false;
                //Irá dar refresh nos itens da grid para que as alterações apareçam na tela
                dtSelecionados.Items.Refresh();
                //revomve do binding o objeto que acabou de adicionar no outro datagrid, para não adicionar o mesmo
                //objeto duas vezes
                cadNaoSelec.RemoveAt(dtJogadores.SelectedIndex);
                //Refresh na datagrid de jogadores, agora sem o jogador adicionado anteriormente
                dtJogadores.Items.Refresh();
            }

        }

        private void AdicionaLista(Cadastro cadast)
        {
            listCad.Add(cadast);
        }

        private void btnApagar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtSelecionados.SelectedIndex >= 0)
            {
                //adiciona o objeto ao binding do datagrid de jogadores ainda não selecionados
                cadNaoSelec.Add(listCad[dtSelecionados.SelectedIndex]);
                //remove o objeto do binding dos jogadores selecionados
                listCad.RemoveAt(dtSelecionados.SelectedIndex);
                
            }
            //refresh no datadrid de jogadores selecionados
            dtSelecionados.Items.Refresh();
            //refresh no datadrid de jogadores  não selecionados
            dtJogadores.Items.Refresh();
        }

        private void btGravar_Click(object sender, RoutedEventArgs e)
        {
            //lista de aventura/personagem
            List<AvenPerVO> avenPer = new List<AvenPerVO>();
           

            
           Aventura a = new Aventura();
           a.NomeAventura = txtNomeAventura.Text;
           a.Senha = pbSenha.Password;
            AventuraDAO dao = new AventuraDAO();

            //fazer um max aventura +1 e atribuir a uma variavel que será usada para incluir a aventura
            int codaven = dao.maxAventura() +1 ;

            for (int i = 0; i < listCad.Count;i++)
            {
                dao.Gravar( codaven, a, listCad[i].Personagem.CodPer); //mudar o dao para inserir o parametro cod aventura

                           } //pedir para o mario trocar o banco
            
                     
            for( int i = 0 ; i < avenPer.Count;i++)
            {
                MessageBox.Show("código da aventura = " + avenPer[i].codAventura.ToString() + " código do personagem = " + avenPer[i].codPer.ToString());
            }
        }


    }
}
