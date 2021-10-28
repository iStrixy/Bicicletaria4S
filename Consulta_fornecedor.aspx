<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta_fornecedor.aspx.cs" Inherits="PROJ_INTER_BC4S.Consulta_fornecedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css"/>
    <title>Bicicletaria 4S - Consulta de fornecedor</title>
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
							<li><a href="Cadastro_cliente.aspx" class="tmenu">Cadastro de cliente</a></li>
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
					<li class="has-submenu"><a href="#" class="tmenu">Consulta</a>
						<ul class="content_menu">
							<li><a href="Consulta_cliente.aspx" class="tmenu">Consulta de cliente</a></li>
							<li><a href="Consulta_produto.aspx" class="tmenu">Consulta de produto</a></li>
							<li><a href="Consulta_servico.aspx" class="tmenu">Consulta de serviço</a></li>
							<li><a href="Consulta_fabricante.aspx" class="tmenu">Consulta de fabricante</a></li>
							<li><a href="#" class="tmenu">Consulta de fornecedor</a></li>
						</ul>
					</li>
						<li id="logout"><asp:LinkButton ID="lb_sair" runat="server" OnClick="lb_sair_Click">Sair</asp:LinkButton></li>
				</ul>
			</nav>
		</header>
	</div>
	<div class="corpo">
		<section id="titulo_consul_forn">
			<p>Consulta de fornecedor</p>
			<div>
				<asp:Label runat="server" ID="lblError"></asp:Label>
			</div>
		</section>
		<div class="consul_forn">
			<asp:GridView ID="gvFornecedor" runat="server" OnSelectedIndexChanged="gvFornecedor_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="NOME" HeaderText="Nome" />
                    <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" />
                    <asp:BoundField DataField="CIDADE" HeaderText="Cidade" />
                    <asp:BoundField DataField="UF" HeaderText="UF" />
                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
		</div>
		<div class="dados_fornecedor" runat="server">
			<div>
				<asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
			</div>
			<div class="campos_consul_fabr">
				Nome:
				<asp:TextBox runat="server" type="text" name="nome_forn" class="input_nome_forn_consul" ID="txtNomeForn"></asp:TextBox>
			</div>
			<div class="campos_consul_fabr">
				Telefone:
				<asp:TextBox runat="server" type="text" name="tel_forn" class="input_tel_forn_consul" ID="txtTelForn"></asp:TextBox>
			</div>
			<div class="campos_consul_fabr">
				Cidade:
				<asp:TextBox runat="server" type="text" name="cidade_forn" class="input_cidade_forn_consul" ID="txtCidadeForn"></asp:TextBox>
				UF:
				<asp:TextBox runat="server" type="text" name="uf_forn" class="input_uf_forn_consul" ID="txtUfForn" Columns="4" MaxLength="2" OnTextChanged="txtUfForn_TextChanged"></asp:TextBox>
				</div>
				<div class="campos_consul_fabr">
					E-mail:
					<asp:TextBox runat="server" type="text" name="email_forn" class="input_email_forn_consul" ID="txtEmailForn"></asp:TextBox>
				</div>
				<br/><br/>
				<asp:Button runat="server" class="btn_consul_salvar" Text="Salvar alterações" ID="btnSalvar" OnClick="btnSalvar_Click"></asp:Button>
				<asp:Button runat="server" class="btn_consul_editar" Text="Editar" ID="btnEditar" OnClick="btnEditar_Click"></asp:Button>
				<asp:Button runat="server" class="btn_consul_remover" Text="Excluir" ID="btnExcluir" OnClick="btnExcluir_Click"></asp:Button>
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