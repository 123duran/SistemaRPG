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
                if (c.Ativo == 1) {

                    MessageBox.Show("Bem vindo jogador! ");
                    WPrincipal princ = new WPrincipal();
                    princ.Show();
                    this.Close();

                }

              /*
                    while (dr.Read())
                    {
                        if (dr["ATIVO"].ToString() == "0")
                            MessageBox.Show("Este usuário está desativado.\n\rContate a administrador para desativar sua conta.");
                        else
                        {
                            if (txtEmail.Text == dr["EMAIL"].ToString() &&
                                txtSenha.Text == dr["SENHA"].ToString())
                            {
                                MessageBox.Show("Bem vindo ao SistemaRPG 3D&T Alpha", "Bem vindo!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                                if (dr["PERFIL"].ToString() == "Administrador")
                                {
                                    WPrincipal wPrincipal = new WPrincipal();
                                    wPrincipal.ShowDialog();
                                    this.Hide();
                                    txtEmail.Text = "";
                                    txtSenha.Clear();
                                }
                                else
                                {
                                    //Se for Usuário ao abrir formulário devera ser desabilitado algumas funções
                                    WPrincipal wPrincipal = new WPrincipal();
                                    wPrincipal.ShowDialog();
                                    this.Hide();
                                    txtEmail.Text = "";
                                    txtSenha.Clear();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Usuário/Senha incorretos, tente novamente!", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }

                    }
               */

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
    }
}
