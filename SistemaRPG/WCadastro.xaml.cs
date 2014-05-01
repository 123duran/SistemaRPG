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
    /// Interaction logic for WCadastro.xaml
    /// </summary>
    public partial class WCadastro : Window
    {
        public WCadastro()
        {
            InitializeComponent();
        }

        private void btnCadastrar(object sender, RoutedEventArgs e)
        {

            // valida se há algum textbox em branco
            if (validaTxt()) 
            {
                // valida se o nome de usuário está dísponivel
                if (!checaUsu(txtNome.Text))
                {
                    CadastraUsu(txtNome.Text, txtEmail.Text, pwSenha.Password);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nome de usuário já existe em nosso banco de dados!");
                    txtNomeUsuario.Focus();
                }
            }
            else {
                MessageBox.Show("Erro ao cadastrar: Preencha todos os campos! ");
            }

           
        }
        /// <summary>
        /// Essa função valida se os campos da tela de cadastro foram todos preenchidos
        /// </summary>
        /// <returns></returns>
        public Boolean validaTxt() {

            if ((txtNome.Text.Length > 0) && (txtEmail.Text.Length > 0) && (txtNomeUsuario.Text.Length > 0) && (pwSenha.Password.Length > 0))
                return true;
            return false;
            
           
        }

        public void CadastraUsu(string nome, string email, string senha)
        {
            Cadastro c = new Cadastro();
            CadastroDAO dao = CadastroDAO.getInstance();
            c.Nome = nome;
            c.Email = email;
            c.Senha = senha;
            c.Ativo = 1;

            MessageBoxResult result = MessageBox.Show("Você gostaria de cadastrar como Mestre?", "Perfil do Jogador", MessageBoxButton.YesNo, MessageBoxImage.Question);

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    c.Perfil = "Administrador";
                    dao.Gravar(c);
                    MessageBox.Show("Cadastro efetuado com sucesso!", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    c.Perfil = "Usuário";
                    dao.Gravar(c);
                    MessageBox.Show("Cadastro efetuado com sucesso!", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contate o suporte\n\rERRO: "
                    + ex.Message.ToString(), "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        
        }

        private void btnChecarDisp_Click(object sender, RoutedEventArgs e)
        {
            if (txtNomeUsuario.Text.Length > 0)
            {
                string usuario = txtNomeUsuario.Text;
                if (checaUsu(usuario))
                {
                    MessageBox.Show("Usuário já cadastrado em nossa base de dados!");
                    txtNomeUsuario.Focus();

                }
                else 
                {
                    MessageBox.Show("Nome de usuário diponível para cadastro.");
                }
            }
            else {
                MessageBox.Show("Preencha o seu nome de usuário por favor!");
            }
        }
        /// <summary>
        /// Checa se o nome de usuário está disponível
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public Boolean checaUsu(string usuario) 
        {
            CadastroDAO dao =  CadastroDAO.getInstance();
            return  dao.checaUsu(usuario);
                        
        }
    }
}
