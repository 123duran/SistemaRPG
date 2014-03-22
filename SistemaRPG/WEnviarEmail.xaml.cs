using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for WEnviarEmail.xaml
    /// </summary>
    public partial class WEnviarEmail : Window
    {
        public WEnviarEmail()
        {
            InitializeComponent();
        }



        public String path
        {
            get { return this.txtCaminho.Text; }
            set { this.txtCaminho.Text = value; }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string emailDestino = "";
            string emailRemetente = "";
            string senhaRemetente = "";
            if ((txtCaminho.Text.Length > 0) && (txtRemetente.Text.Length > 0))
            {
                emailDestino = txtEmail.Text;
                emailRemetente = txtRemetente.Text;
                senhaRemetente = psSenha.Password;

                try
                {
                    enviaEmail(emailDestino, emailRemetente, senhaRemetente);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ocorreu um erro ao enviar o e-mail: " + error.ToString());
                }
            }
        }

        public void enviaEmail(string emailDestino, string emailRemetente, string senhaRemetente)
        {
            MailMessage Email = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            MailAddress sDe = new MailAddress(emailRemetente);

            
            Email.To.Add(emailDestino);
            Email.From = sDe;
            Email.Priority = MailPriority.Normal;
            Email.IsBodyHtml = false;
            Email.Subject = "Te enviaram a ficha de um personagem";
            Email.Body = "Este e-mail contém a ficha do personagem em formato XML em anexo para importação no sistema de RPG.";

            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(txtCaminho.Text);
            Email.Attachments.Add(attachment);

            SmtpServer.Port = 587;

            
            SmtpServer.Credentials = new System.Net.NetworkCredential(emailRemetente,senhaRemetente);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(Email);
            MessageBox.Show("E-mail enviado com sucesso!");
            this.Close();



        }
    }
}
