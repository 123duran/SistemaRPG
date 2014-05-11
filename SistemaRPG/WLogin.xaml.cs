using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for WLogin.xaml
    /// </summary>
    public partial class WLogin : Window
    {         
        public WLogin()
        {
            InitializeComponent();
        }
        
        private void btLogin(object sender, RoutedEventArgs e)
        {
            ValidaUsuario();
        }

        public int login;
        public int getLogin
        {
            get { return login; }
            set { login = value; }
        }

        private void ValidaUsuario()
        {
            Cadastro c = new Cadastro();
            CadastroDAO dao = new CadastroDAO();

            string emailLogin= txtEmail.Text;
            string senhaLogin = txtSenha.Password;
            c = dao.SelecionaCadastro(emailLogin,senhaLogin); 

 
            try
            {
                if (c.Ativo == 1)
                {
                    if (c.Perfil == "Administrador")
                    {
                        MessageBox.Show("Bem vindo ");
                        WPrincipal princ = new WPrincipal();
                        login = c.CodLogin;
                        princ.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bem vindo ");
                        WPrincipalUsuario princUser = new WPrincipalUsuario();
                        princUser.Show();
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Falha no login: Usuário não encontrado/senha incorreta");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Contate o suporte\n\rERRO: "
                    + e.Message.ToString(), "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                Conexao.fecharConexao();
            }
        }

        private void lblCadastro(object sender, MouseButtonEventArgs e)
        {
            WCadastro cadastra = new WCadastro();
            cadastra.ShowDialog();
        }

        private void lblSair_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
