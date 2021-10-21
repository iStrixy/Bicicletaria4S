<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta_servico.aspx.cs" Inherits="PROJ_INTER_BC4S.Consulta_servico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css"/>
    <title>Bicicletaria 4S - Consulta de servico</title>
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
							<li><a href="#" class="tmenu">Consulta de serviço</a></li>
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
		<section id="titulo_consul_serv">
			<p>Consulta de serviço</p>
		</section>
		<form class="consul_serv" runat="server">
			<asp:GridView ID="gvServico" runat="server"></asp:GridView>
			<div class="dados_serv" runat="server">
				<div class="campo_consul_serv">
					Descrição:
					<asp:TextBox runat="server" type="text" name="descricao" class="input_desc_serv_consul" ID="txtDescricaoServico"></asp:TextBox>
				</div>
				<div class="campo_consul_serv">
					Valor:
					<asp:TextBox runat="server" type="text" name="valor" class="input_vlr_serv_consul" ID="txtValorServico"></asp:TextBox>
				</div>
				<br /><br />
				<asp:Button runat="server" class="btn_consul_salvar" Text="Salvar alterações" ID="btnSalvar" OnClick="btnSalvar_Click"></asp:Button>
				<asp:Button runat="server" class="btn_consul_editar" Text="Editar" ID="btnEditar" OnClick="btnEditar_Click"></asp:Button>
				<asp:Button runat="server" class="btn_consul_remover" Text="Excluir" ID="btnExcluir" OnClick="btnExcluir_Click"></asp:Button>
			</div>
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
