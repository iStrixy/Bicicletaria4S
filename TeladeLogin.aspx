<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeladeLogin.aspx.cs" Inherits="PROJ_INTER_BC4S.TeladeLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="/styles/telalogin.css" />
    <title>Bicicletaria 4S - Login</title>
</head>
<body>
    <div class="centro">
        <h1>
            <img src="imagens/Logotipo.png" /></h1>
        <form id="form1" runat="server">
            <div class="text_field">
                <asp:TextBox class="textbox" ID="tb_user" runat="server" OnTextChanged="tb_user_TextChanged"></asp:TextBox>
                <asp:Label class="inp_label" ID="lb_user" runat="server" Text="Usuário"></asp:Label>
            </div>
            <div class="text_field">
                <asp:TextBox  type="password" class="textbox" ID="tb_pw" runat="server" OnTextChanged="tb_pw_TextChanged"></asp:TextBox>
                <asp:Label class="inp_label" ID="lb_pw" runat="server" Text="Senha"></asp:Label>
            </div>
            <div class="lberror">

                <asp:Label ID="lb_error" runat="server" Font-Names="poppins" ForeColor="Red"></asp:Label>

            </div>
            <div>
                <a href="Index.html">
                    <asp:Button ID="bt_entrar" runat="server" Text="Entrar" OnClick="bt_entrar_Click" />
                </a>
            </div>
        </form>
    </div>
</body>
</html>
