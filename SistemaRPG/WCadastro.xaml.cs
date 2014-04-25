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
            Cadastro c = new Cadastro();
            CadastroDAO dao = CadastroDAO.getInstance();
            c.Nome = txtNome.Text;
            c.Email = txtEmail.Text;
            c.Senha = pwSenha.Password;
            c.Perfil = "Administrador";
            c.Ativo = 1;
            
            try
            {
                dao.Gravar(c);
                MessageBox.Show("Cadastro efetuado com sucesso!", "Cadastro", MessageBoxButton.OK, MessageBoxImage.Asterisk);
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

        public Boolean checaUsu(string usuario) 
        {
            CadastroDAO dao =  CadastroDAO.getInstance();
            return  dao.checaUsu(usuario);
                        
        }
    }
}
