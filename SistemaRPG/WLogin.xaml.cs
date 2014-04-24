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
        Conexao cnLogin = new Conexao();
        Cadastro user;
                
       
        public WLogin()
        {
            InitializeComponent();
        }

        const string conec = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\RPG\SistemaRPG.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        SqlConnection cn = new SqlConnection(conec);
        
        private void btLogin(object sender, RoutedEventArgs e)
        {
            ValidaUsuario();
        }

        private void Label_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            
            WCadastro cadastra = new WCadastro();
            cadastra.ShowDialog();
        }

        private void ValidaUsuario()
        {
            Cadastro c = new Cadastro();
            CadastroDAO dao = new CadastroDAO();

            c.Email = txtEmail.Text;
            c.Senha = txtSenha.Text;
            SqlDataReader dr = dao.Seleciona(c);

 
            try
            {
                if (!dr.HasRows)
                    MessageBox.Show("Usuário não existe. \nTente novamente.", "Login Falhou", MessageBoxButton.OK, MessageBoxImage.Error);

                else
                {
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
                }
                dr.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Contate o suporte\n\rERRO: "
                    + e.Message.ToString(), "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                
                //cnLogin.fecharConexao();
            }
        }
    }
}
