<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Login.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Login ID="telaLogin" runat="server" OnAuthenticate="Login_Authenticate" Height="213px" PasswordLabelText="Senha:" RememberMeText="Lembrar-me" TitleText="Efetuar Login" UserNameLabelText="E-mail" Width="309px">
        </asp:Login>
    
    </div>
    </form>
</body>
</html>
