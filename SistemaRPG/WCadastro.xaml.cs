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
            c.Senha = pwSenha.Password ;//pwSenha.ToString();
            c.Perfil = "Administrador";
            c.Ativo = 1;
            dao.Gravar(c);
        }

    }
}
