<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_produto.aspx.cs" Inherits="PROJ_INTER_BC4S.Cadastro_produto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bicicletaria 4S - Cadastro de produto</title>
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
							<li><a href="#" class="tmenu">Cadastro de produto</a></li>
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
							<li><a href="Consulta_fornecedor.aspx" class="tmenu">Consulta de fornecedor</a></li>
						</ul>
					</li>
						<li id="logout"><a href="#" class="tmenu">Sair</a></li>
				</ul>
			</nav>
		</header>
	</div>

	<div class="corpo">
		<section id="titulo_cad_prod">
			<p>Cadastro de produto</p>
		</section>
		<br/><br/>
		<form method="post" class="form_cad_prod" runat="server">
			<div class="campos_cad_prod" id="nome_prod_fabr">
				Fabricante:
				<select runat="server" multiple="false" id="slcNomeFabricanteProduto"> </select>
			</div><br/>
			<div class="campos_cad_prod" id="nome_prod_forn">
				Fornecedor: 
				<select runat="server" multiple="false" id="slcNomeFornecedorProduto"> </select>
			</div><br/>
			<div class="campo_cad_prod" id="desc_prod">
				Descrição: 
				<asp:TextBox runat="server" type="text" name="descricao" class="input_desc_prod" required="" ID="txtDescricaoProduto" OnTextChanged="txtDescricaoProduto_TextChanged"></asp:TextBox>
			</div><br/>
			<div class="campo_cad_prod" id="valor_unit_prod">
				Valor unitário: 
				<asp:TextBox runat="server" type="number" name="vlr_uni_prod" class="input_valor_unit_prod" required="" ID="txtValorUniProduto" OnTextChanged="txtValorUniProduto_TextChanged"></asp:TextBox>
			</div>
			<br/><br/>
			<asp:Button runat="server" class="btn_cad_prod" Text="Cadastrar produto" ID="btnCadastrarProduto" OnClick="btnCadastrarProduto_Click"></asp:Button>
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
