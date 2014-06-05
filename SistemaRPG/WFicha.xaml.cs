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
        
        Personagem ficha = new Personagem();
        WSelecionarImagem wImg = new WSelecionarImagem();
        int img = 0;
        string lvlPer = "0";
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

            ficha.ResPer = res;
            ficha.PvPer = ficha.ResPer * 2;//calcula o valor máximo de pontos de vida do personagem, usando a fórmula (PDV = RES *2)
            lblPV.Content = ficha.PvPer.ToString(); // Preenche o label relativo aos pontos de vida



        }

        public void prenche()
        {
            retornaImagemSelecionada(img);
            string varTemp = "";

            //Insere o nome do personagem na ficha
            if (txtNomePer.Text.Length > 0)
            {
                ficha.NomePer = txtNomePer.Text;
            }
            else
            {
                varTemp += " Nome do personagem";
            }

            //Insere a armadura do personagem na ficha
            if (txtArm.Text.Length > 0)
            {
                ficha.ArmPer = Convert.ToInt32(txtArm.Text);
            }
            else
            {
                varTemp += " Armadura";
            }
            if (txtForca.Text.Length > 0)
            {
                ficha.ForcaPer = Convert.ToInt32(txtForca.Text);
            }
            else
            {
                varTemp += " Força";
            }

            if (txtHabil.Text.Length > 0)
            {
                ficha.HabPer = Convert.ToInt32(txtHabil.Text);
            }
            else
            {
                varTemp += " Habilidade";
            }
            if (txtPDF.Text.Length > 0)
            {
                ficha.PdfPer = Convert.ToInt32(txtPDF.Text);
            }
            else
            {
                varTemp += " Poder de Fogo";
            }
            if (txtRaca.Text.Length > 0)
            {
                ficha.RacaPer = txtRaca.Text;
            }
              else
            {
                varTemp += " Raça";
            }
            if (txtVantagens.Text.Length > 0)
            {
                ficha.Vantagens = txtVantagens.Text;
            }
            else 
            {
                varTemp += "Vantagens";
            }

            if (txtDesvantagens.Text.Length > 0)
            {
                ficha.Desvantagens = txtDesvantagens.Text;
            }
            else
            {
                varTemp += "Vantagens";
            }
            ficha.NivelPer =Convert.ToInt32(txtNivel.Text);

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
                ficha.ImgPer = 1;
            }
            else if (img != 0)
            {
                ficha.ImgPer = img;
            }



        }

        public void escreverFicha(string lvlPer) {

            ficha.NivelPer = Convert.ToInt32(lvlPer);
            prenche();
            ManipulaXML mani = new ManipulaXML();
            mani.escrever(ficha);
            PersonagemDAO dao = new PersonagemDAO();
            dao.Gravar(ficha);
            this.Close();
        
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           

        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            //WSelecionarImagem frm = new WSelecionarImagem();
            MessageBox.Show(wImg.getImagem.ToString());
            wImg.ShowDialog();
            MessageBox.Show(wImg.getImagem.ToString());
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            //WSelecionarImagem frm = new WSelecionarImagem();
            MessageBox.Show(wImg.getImagem.ToString());
            wImg.ShowDialog();
            MessageBox.Show(wImg.getImagem.ToString());
         
        }

        private void Image_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Seu personagem é um NPC?", "Importante!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                lvlPer = txtNivel.Text;
                if (txtNivel.Text.Length > 0)
                {
                    ficha.TipoPer = "NPC";
                    escreverFicha(lvlPer);
                }
                else
                {
                    MessageBox.Show("Insira o nível do seu Pesonagem por favor.");
                }


            }
            else
            {

                ficha.TipoPer = "personagem";
                escreverFicha(lvlPer);
            }
        }

        private void Image_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            wImg.Close();
            this.Close();
        }


    }
}
