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
            Cadastro cadastro = new Cadastro();
            CadastroDAO dao = CadastroDAO.getInstance();
            cadastro.Nome = txtNome.Text;
            cadastro.Email = txtEmail.Text;
            cadastro.Senha = pwSenha.Password;
            cadastro.Perfil = "Administrador";
            cadastro.Ativo = 1;
            dao.Gravar(cadastro);
        }

    }
}
