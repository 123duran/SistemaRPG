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
            Login login = new Login();
            CadastroDAO dao = CadastroDAO.getInstance();
            login.Nome = txtNome.Text;
            login.Email = txtEmail.Text;
            login.Senha = pwSenha.Password ;//pwSenha.ToString();
            login.Perfil = "Administrador";
            login.Ativo = 1;
            dao.Gravar(login);
        }

    }
}
