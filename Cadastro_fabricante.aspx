<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_fabricante.aspx.cs" Inherits="PROJ_INTER_BC4S.Cadastro_fabricante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bicicletaria 4S - Cadastro de fabricante</title>
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css" />
</head>

<body>
    <form id="form1" runat="server" method="post">
        <div class="menu" id="topo">
            <header>
                <div class="logo">
                    <a href="Index.aspx">
                        <img src="Imagens/Logotipo.png" alt="logotipo_site" />
                    </a>
                </div>
                <nav>
                    <ul class="menu">
                        <li><a href="Index.aspx" class="tmenu">Início</a></li>
                        <li class="has-submenu"><a href="#" class="tmenu">Cadastro</a>
                            <ul class="content_menu">
                                <li><a href="Cadastro_cliente.aspx" class="tmenu">Cadastro de cliente</a></li>
                                <li><a href="Cadastro_produto.aspx" class="tmenu">Cadastro de produto</a></li>
                                <li><a href="Cadastro_servico.aspx" class="tmenu">Cadastro de serviço</a></li>
                                <li><a href="#" class="tmenu">Cadastro de fabricante</a></li>
                                <li><a href="Cadastro_fornecedor.aspx" class="tmenu">Cadastro de fornecedor</a></li>
                            </ul>
                        </li>
                        <li class="has-submenu"><a href="#" class="tmenu">Orçamento</a>
                            <ul>
                                <li><a href="Orcamento.aspx" class="tmenu">Novo orçamento</a></li>
                                <li><a href="Ordem_servico.aspx" class="tmenu">Ordem de serviço</a></li>
                            </ul>
                        </li>
                        <li class="has-submenu"><a href="#" class="tmenu">Consulta</a>
                            <ul class="content_menu">
                                <li><a href="Consulta_cliente.aspx" class="tmenu">Consulta de cliente</a></li>
                                <li><a href="Consulta_produto.aspx" class="tmenu">Consulta de produto</a></li>
                                <li><a href="Consulta_servico.aspx" class="tmenu">Consulta de serviço</a></li>
                                <li><a href="Consulta_fabricante.aspx" class="tmenu">Consulta de fabricante</a></li>
                                <li><a href="Consulta_fornecedor.aspx" class="tmenu">Consulta de fornecedor</a></li>
                            </ul>
                        </li>
                        <li id="logout">
                            <asp:LinkButton ID="lb_sair" runat="server" OnClick="lb_sair_Click">Sair</asp:LinkButton></li>
                    </ul>
                </nav>
            </header>
        </div>
        <div class="corpo">
            <section id="titulo_cad_fabr">
                <p>Cadastro de fabricante</p>
            </section>
            <div>
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </div>
            <br />
            <div class="form_cad_fabr">
                <div class="campos_cad_fabr" id="nome_cad_fabr">
                    Nome:
				<asp:TextBox runat="server" type="text" name="nome_fabr" class="input_nome_fabr" required="" ID="txtNomeFabricante" OnTextChanged="txtNomeFabricante_TextChanged"></asp:TextBox>
                </div>
                <br />
                <div class="campos_cad_fabr" id="telefone_cad_fabr">
                    Telefone:
				<asp:TextBox runat="server" type="numer" name="tel_fabr" class="input_tel_fabr" required="" ID="txtTelefoneFabricante" OnTextChanged="txtTelefoneFabricante_TextChanged"></asp:TextBox>
                </div>
                <br />
                <div class="campos_cad_fabr" id="cidade_fabr">
                    Cidade:
				<asp:TextBox runat="server" type="text" name="cidade_fabr" class="input_cidade_fabr" required="" ID="txtCidadeFabricante" OnTextChanged="txtCidadeFabricante_TextChanged"></asp:TextBox>
                    <div class="uf">
                        UF:
				<asp:DropDownList ID="DpUF" runat="server" Height="26px" Width="94px">
                    <asp:ListItem Selected="True">Selecione...</asp:ListItem>
                    <asp:ListItem>AC</asp:ListItem>
                    <asp:ListItem>AL</asp:ListItem>
                    <asp:ListItem>AP</asp:ListItem>
                    <asp:ListItem>AM</asp:ListItem>
                    <asp:ListItem>BA</asp:ListItem>
                    <asp:ListItem>CE</asp:ListItem>
                    <asp:ListItem>DF</asp:ListItem>
                    <asp:ListItem>ES</asp:ListItem>
                    <asp:ListItem>GO</asp:ListItem>
                    <asp:ListItem>MA</asp:ListItem>
                    <asp:ListItem>MT</asp:ListItem>
                    <asp:ListItem>MS</asp:ListItem>
                    <asp:ListItem>MG</asp:ListItem>
                    <asp:ListItem>PA</asp:ListItem>
                    <asp:ListItem>PB</asp:ListItem>
                    <asp:ListItem>PR</asp:ListItem>
                    <asp:ListItem>PE</asp:ListItem>
                    <asp:ListItem>PI</asp:ListItem>
                    <asp:ListItem>RJ</asp:ListItem>
                    <asp:ListItem>RN</asp:ListItem>
                    <asp:ListItem>TO</asp:ListItem>
                    <asp:ListItem>RS</asp:ListItem>
                    <asp:ListItem>RO</asp:ListItem>
                    <asp:ListItem>RR</asp:ListItem>
                    <asp:ListItem>SC</asp:ListItem>
                    <asp:ListItem>SP</asp:ListItem>
                    <asp:ListItem>SE</asp:ListItem>
                </asp:DropDownList>
                    </div>
                </div>
                <br />
                <br />
                <asp:Button runat="server" class="btn_cad_fabr" ID="btnCadastrarFabricante" Text="Cadastrar" OnClick="btnCadastrarFabricante_Click"></asp:Button>
            </div>
        </div>
        <footer>
            <div class="topicos" id="topicos-principais">
                <h3><b>Menu</b></h3>
                <p><a href="Index.aspx" class="trodape">Início</a></p>
                <p><a href="Menu_cadastro.aspx" class="trodape">Cadastro</a></p>
                <p><a href="Menu_consulta.aspx" class="trodape">Consulta</a></p>
                <p><a href="Menu_orcamento.aspx" class="trodape">Orçamento</a></p>
            </div>
            <div class="topicos" id="topicos-sobre">
                <h3><b>Sobre</b></h3>
                <p><a href="Quem_somos.aspx" class="trodape">Quem somos</a></p>
            </div>
            <div class="topicos" id="topicos-contatos">
                <h3><b>Telefones para contato:</b></h3>
                <p>(17) 99724-3466</p>
                <p>(17) 3542-7605</p>
            </div>
        </footer>
    </form>
</body>
</html>
