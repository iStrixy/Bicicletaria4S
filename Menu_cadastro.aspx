<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_cadastro.aspx.cs" Inherits="PROJ_INTER_BC4S.Menu_cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css"/>
    <title>Bicicletaria 4S - Menu de cadastros</title>
</head>

<body>
	<form id="form1" runat="server">
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
					<li class="has-submenu"><a href="#">Cadastro</a>
						<ul class="content_menu">
							<li><a href="Cadastro_cliente.aspx" >Cadastro de cliente</a></li>
							<li><a href="Cadastro_produto.aspx">Cadastro de produto</a></li>
							<li><a href="Cadastro_servico.aspx">Cadastro de serviço</a></li>
							<li><a href="Cadastro_fabricante.aspx">Cadastro de fabricante</a></li>
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
		<section id="titulo_menu_cad">
			<p>Cadastramento</p>
		</section>
		<div class="conteudo_menu_cad">
			<div>
				<p><a href="Cadastro_cliente.aspx" class="menu_cad">Cliente</a></p>
				<p><a href="Cadastro_produto.aspx" class="menu_cad">Produto</a></p>
				<p><a href="Cadastro_servico.aspx" class="menu_cad">Serviço</a></p>
				<p><a href="Cadastro_fabricante.aspx" class="menu_cad">Fabricante</a></p>
				<p><a href="Cadastro_fornecedor.aspx" class="menu_cad">Fornecedor</a></p>
				<p><a href="Cadastro_usuario.aspx" class="menu_cad">Cadastro de usuário</a></p>
			</div>
		</div>
	</div>
	<footer>
		<div class="topicos" id="topicos-principais">
			<h3><b>Menu</b></h3>
			<p><a href="Index.aspx" class="trodape">Início</a></p>
			<p><a href="#" class="trodape">Cadastro</a></p>
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