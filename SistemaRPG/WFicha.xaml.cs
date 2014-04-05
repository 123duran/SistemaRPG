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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SistemaRPG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PerBO ficha = new PerBO();
        WSelecionarImagem wImg = new WSelecionarImagem();
        int img = 0;
        public MainWindow()
        {

            InitializeComponent();



        }

        int res = 0;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            wImg.Close();
            this.Close();
        }

        /// <summary>
        /// Este método irá calcular o máximo de Pontos de vida do jogador e após isso preencher o label correspondente.
        /// Recebe o conteúdo do textbox da resistência, devidamente convertido em uma váriavel do tipo int
        /// Este método tambeém preenche os atributos resPer e pdvPer do objeto ficha. 
        /// </summary>
        /// <param name="res"></param>
        public void calculaMaxPV(int res)
        {

            ficha.resPer = res;
            ficha.pdvPer = ficha.resPer * 2;//calcula o valor máximo de pontos de vida do personagem, usando a fórmula (PDV = RES *2)
            lblPV.Content = ficha.pdvPer.ToString(); // Preenche o label relativo aos pontos de vida



        }

        public void prenche()
        {
            retornaImagemSelecionada(img);
            string varTemp = "";

            //Insere o nome do personagem na ficha
            if (txtNomePer.Text.Length > 0)
            {
                ficha.nomePer = txtNomePer.Text;
            }
            else
            {
                varTemp += " Nome do personagem";
            }

            //Insere a armadura do personagem na ficha
            if (txtArm.Text.Length > 0)
            {
                ficha.armPer = Convert.ToInt32(txtArm.Text);
            }
            else
            {
                varTemp += " Armadura";
            }
            if (txtForca.Text.Length > 0)
            {
                ficha.forcaPer = Convert.ToInt32(txtForca.Text);
            }
            else
            {
                varTemp += " Força";
            }

            if (txtHabil.Text.Length > 0)
            {
                ficha.habPer = Convert.ToInt32(txtHabil.Text);
            }
            else
            {
                varTemp += " Habilidade";
            }
            if (txtPDF.Text.Length > 0)
            {
                ficha.pdfPer = Convert.ToInt32(txtPDF.Text);
            }
            else
            {
                varTemp += " Poder de Fogo";
            }
            if (txtRaca.Text.Length > 0)
            {
                ficha.racaPer = txtRaca.Text;
            }
            else
            {
                varTemp += " Raça";
            }
            ficha.tipoPer = "personagem";
        }

        private void txtRes_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (txtRes.Text.Count() > 0)
            {
                calculaMaxPV(res = Convert.ToInt32(txtRes.Text));
            }

        }


        /// <summary>
        /// Recebe o valor da imagem selecionada no form WSelecionarImagem, caso o form não tenha sido aberto ele irá colocar a imagem do humano padrão (1)
        /// </summary>
        /// <param name="img"></param>
        public void retornaImagemSelecionada(int img)
        {
            //variável local recebe valor setado no form WSelecionarImagem através do método getImagem
            img = wImg.getImagem;
            if ((img == 0))
            {
                ficha.imgPer = 1;
            }
            else if (img != 0)
            {
                ficha.imgPer = img;
            }



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            prenche();
            ManipulaXML mani = new ManipulaXML();
            mani.escrever(ficha);
            this.Close();
          

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //WSelecionarImagem frm = new WSelecionarImagem();
            MessageBox.Show(wImg.getImagem.ToString());
            wImg.ShowDialog();
            MessageBox.Show(wImg.getImagem.ToString());
        }


    }
}
