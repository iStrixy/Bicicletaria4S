<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_cliente.aspx.cs" Inherits="PROJ_INTER_BC4S.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Bicicletaria 4S - Cadastramento</title>
	<link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css"/>
</head>

<body>
    <form id="form1" runat="server" method="post">
    <div class="menu" id="topo">
        <header>
            <div class="logo">
                <a href="Index.aspx">
                    <img src="Imagens/Logotipo.png" alt="logotipo_site"/>
                </a>
            </div>
            <nav>
                <ul class="menu">
                    <li><a href="Index.aspx" class="tmenu">Início</a></li>
                    <li class="has-submenu"><a href="#" class="tmenu">Cadastro</a>
                        <ul class="content_menu">
                            <li><a href="#" class="tmenu">Cadastro de cliente</a></li>
                            <li><a href="Cadastro_produto.aspx" class="tmenu">Cadastro de produto</a></li>
                            <li><a href="Cadastro_servico.aspx" class="tmenu">Cadastro de serviço</a></li>
                            <li><a href="Cadastro_fabricante.aspx" class="tmenu">Cadastro de fabricante</a></li>
                            <li><a href="Cadastro_fornecedor.aspx" class="tmenu">Cadastro de fornecedor</a></li>
                        </ul>
                    </li>
                    <li class="has-submenu"><a href="#" class="tmenu">Orçamento</a>
                        <ul>
                            <li><a href="Orcamento.aspx" class="tmenu">Novo orçamento</a></li>
                            <li><a href="Ordem_servico.aspx" class="tmenu">Ordem de serviço</a></li>
                        </ul>
                    </li>
                    <li class="has-submenu"><a href="#" class="tmenu">Usuário</a>
						<ul class="content_menu">
							<li><a href="Cadastro_usuario.aspx" class="tmenu">Cadastro de usuário</a></li>
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
                    <li id="logout"><asp:LinkButton ID="lb_sair" runat="server" OnClick="lb_sair_Click">Sair</asp:LinkButton></li>
                </ul>
            </nav>
        </header>
    </div>
    <div class="corpo">
        <section id="titulocadastramento">
            <p>Cadastro de cliente</p>
        </section>
        <div>
            <asp:Label runat="server" ID="lblError"></asp:Label>
        </div>
        <br/>
        <div class="form_cadastramento">
            <div class="campos" id="nome">
                Nome:
                <asp:Textbox runat="server" type="text" name="nome" class="inputname" placeholder="Ex. João Silva" ID="tb_nome" OnTextChanged="tb_nome_TextChanged"></asp:Textbox>
            </div>
            <div class="campos" id="rua">
                Rua:
                <asp:Textbox runat="server" type="text" name="rua" class="inputstreet" ID="tb_rua"></asp:Textbox>
            </div>
            <div class="campos" id="endereco">
                Número:
                <asp:Textbox runat="server" type="text" name="numero" class="inputnumber"  ID="tb_number"></asp:Textbox>
                Bairro:
                <asp:Textbox runat="server" type="text" name="bairro" class="inputdistrict"  ID="tb_bairro"></asp:Textbox>
            </div>
            <div class="campos" id="complemento">
                Complemento:
                <asp:Textbox runat="server" type="text" name="complemento" class="inputcomplement" placeholder="Ex. Casa" ID="tb_cmpt"></asp:Textbox>
            </div>
            <div class="campos" id="cep">
                CEP:
                <asp:Textbox runat="server" type="text" name="cep" class="inputcep" placeholder="xxxxx-xxx" ID="tb_cep"></asp:Textbox>
            </div>
            <div class="campos" id="cpf">
                CPF:
                <asp:Textbox runat="server" type="text" name="cpf" class="inputcpf" placeholder="xxx.xxx.xxx-xx" ID="tb_cpf" OnTextChanged="tb_cpf_TextChanged"></asp:Textbox>
            </div>
            <div class="campos" id="email">
                E-mail:
                <asp:Textbox runat="server" type="text" name="email" class="inputemail" placeholder="user@gmail.com" ID="tb_email" OnTextChanged="tb_email_TextChanged"></asp:Textbox>
            </div>
            <div class="campos" id="tel">
                Telefone:
                <asp:Textbox runat="server" type="text" name="telefone" class="inputphone" placeholder="(xx) xxxxx-xxxx" ID="tb_tel"></asp:Textbox>
            </div>
            <asp:Button runat="server" class="enviar-cadastramento" ID="bt_cadastrar" Text="Cadastrar" OnClick="bt_cadastrar_Click"></asp:Button>
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
            <p><a href="Quem_somos.aspx" style="text-decoration: none;" class="trodape">Quem somos</a></p>
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