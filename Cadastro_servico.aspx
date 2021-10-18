<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_servico.aspx.cs" Inherits="PROJ_INTER_BC4S.Cadastro_servico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bicicletaria 4S - Cadastro de serviço</title>
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css"/>
</head>
<body>
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
							<li><a href="#" class="tmenu">Cadastro de serviço</a></li>
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
							<li><a href="Consulta_fornecedor.aspx" class="tmenu">Consulta de fornecedor</a></li>
						</ul>
					</li>
						<li id="logout"><a href="#" class="tmenu">Sair</a></li>
				</ul>
			</nav>
		</header>
	</div>

	<div class="corpo">
		<section id="titulo_cad_serv">
			<p>Cadastro de serviço</p>
		</section>
		<br/><br/>
		<form method="post" class="form_cad_serv" runat="server">
			<div class="campo_cad_serv" id="desc_serv">
				Descrição:
				<asp:TextBox runat="server" type="text" name="descricao" class="input_desc_serv" required="" ID="txtDescricaoServico" OnTextChanged="txtDescricaoServico_TextChanged"></asp:TextBox>
			</div><br/>
			<div class="campo_cad_serv" id="valor_serv">
				Valor:
				<asp:TextBox runat="server" type="number" name="vlr_serv" class="input_valor_serv" required="" ID="txtValorServico" OnTextChanged="txtValorServico_TextChanged"></asp:TextBox>
			</div>
			<br/><br/>
			<asp:Button runat="server" class="btn_cad_serv" Text="Cadastrar produto" ID="btnCadastrarServico" OnClick="btnCadastrarServico_Click"></asp:Button>
		</form>
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
</body>
</html>
