using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Login
{
    public partial class login : System.Web.UI.Page
    {
        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if ((telaLogin.UserName == "admin") && (telaLogin.Password == "123"))
            {
                e.Authenticated = true;
                FormsAuthentication.RedirectFromLoginPage(telaLogin.UserName, false);
            }
            else 
            {
                e.Authenticated = false;
            }
             
        }
    }
}