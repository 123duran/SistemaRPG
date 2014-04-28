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

        private void ValidaUsuario()
        {
            Cadastro c = new Cadastro();
            CadastroDAO dao = new CadastroDAO();

            string emailLogin= txtEmail.Text;
            string senhaLogin = txtSenha.Password;
            c = dao.Seleciona(emailLogin,senhaLogin); 

 
            try
            {
                if (c.Ativo == 1)
                {

                    MessageBox.Show("Bem vindo jogador! ");
                    WPrincipal princ = new WPrincipal();
                    princ.Show();
                    this.Close();

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
