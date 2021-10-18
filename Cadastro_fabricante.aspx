﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro_fabricante.aspx.cs" Inherits="PROJ_INTER_BC4S.Cadastro_fabricante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bicicletaria 4S - Cadastro de fabricante</title>
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
						<li id="logout"><a href="#" class="tmenu">Sair</a></li>
				</ul>
			</nav>
		</header>
	</div>

	<div class="corpo">
		<section id="titulo_cad_fabr">
			<p>Cadastro de fabricante</p>
		</section>
		<br/><br/>
		<form method="post" class="form_cad_fabr" runat="server">
			<div class="campos_cad_fabr" id="nome_cad_fabr">
				Nome:
				<asp:TextBox runat="server" type="text" name="nome_fabr" class="input_nome_fabr" required="" ID="txtNomeFabricante" OnTextChanged="txtNomeFabricante_TextChanged"></asp:TextBox>
			</div><br/>
			<div class="campos_cad_fabr" id="telefone_cad_fabr">
				Telefone:
				<asp:TextBox runat="server" type="numer" name="tel_fabr" class="input_tel_fabr" required="" ID="txtTelefoneFabricante" OnTextChanged="txtTelefoneFabricante_TextChanged"></asp:TextBox>
			</div><br/>
			<div class="campos_cad_fabr" id="cidade_fabr">
				Cidade:
				<asp:TextBox runat="server" type="text" name="cidade_fabr" class="input_cidade_fabr" required="" ID="txtCidadeFabricante" OnTextChanged="txtCidadeFabricante_TextChanged"></asp:TextBox>
				UF:
				<select id="slcEstadoFabricante" runat="server" multiple="false">
						<option value="1" text="RO" runat="server"></option>
						<option value="2" text="AC" runat="server"></option>
						<option value="3" text="AM" runat="server"></option>
						<option value="4" text="RR" runat="server"></option>
						<option value="5" text="PA" runat="server"></option>
						<option value="6" text="AP" runat="server"></option>
						<option value="7" text="TO" runat="server"></option>
						<option value="8" text="MA" runat="server"></option>
						<option value="9" text="PI" runat="server"></option>
						<option value="10" text="CE" runat="server"></option>
						<option value="11" text="RN" runat="server"></option>
						<option value="12" text="PB" runat="server"></option>
						<option value="13" text="PE" runat="server"></option>
						<option value="14" text="AL" runat="server"></option>
						<option value="15" text="SE" runat="server"></option>
						<option value="16" text="BA" runat="server"></option>
						<option value="17" text="MG" runat="server"></option>
						<option value="18" text="ES" runat="server"></option>
						<option value="19" text="RJ" runat="server"></option>
						<option value="20" text="SP" runat="server" selected="selected"></option>
						<option value="21" text="PR" runat="server"></option>
						<option value="22" text="SC" runat="server"></option>
						<option value="23" text="RS" runat="server"></option>
						<option value="24" text="MS" runat="server"></option>
						<option value="25" text="MT" runat="server"></option>
						<option value="26" text="GO" runat="server"></option>
						<option value="27" text="DF" runat="server"></option>
				</select>
			</div>
			<br/><br/>
            <asp:Button runat="server" class="btn_cad_fabr" ID="btnCadastrarFabricante" Text="Cadastrar" OnClick="btnCadastrarFabricante_Click"></asp:Button>
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
