<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Login._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>teste</title>
</head>
<body>
    <form id="form1" runat="server">
    <div >
    
        Logado como:    <asp:LoginName ID="LoginName1" runat="server" /> </div>
       
         <div >
    
        Rolar dado de 6 faces:</div>
        

        &nbsp;
        

        <asp:Button ID="Button1" runat="server" Text="Rolar Dado" OnClick="Button1_Click" Width="110px"         />
        

        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        

    </form>


</body>
</html>
