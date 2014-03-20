using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Login
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            double i = 0;
            Random random = new Random();
            i = random.Next(1, 7);
            ClientScript.RegisterStartupScript(this.GetType(), "Aviso", "confirm('" +" Você tirou "+ i.ToString()+" no dado" + "');", true);
         //  Response.Write("<script>alert('Olá mundo')</script>");
          
        }
    }
}