<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta_fabricante.aspx.cs" Inherits="PROJ_INTER_BC4S.Consulta_fabricante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css"/>
    <title>Bicicletaria 4S - Consulta de fabricante</title>
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
							<li><a href="#" class="tmenu">Consulta de fabricante</a></li>
							<li><a href="Consulta_fornecedor.aspx" class="tmenu">Consulta de fornecedor</a></li>
						</ul>
					</li>
						<li id="logout"><asp:LinkButton ID="lb_sair" runat="server" OnClick="lb_sair_Click">Sair</asp:LinkButton></li>
				</ul>
			</nav>
		</header>
	</div>

	<div class="corpo">
		<section id="titulo_consul_fabr">
			<p>Consulta de fabricante</p>
		</section>
		<div class="consul_fabr">
			<asp:GridView ID="gvFabricante" runat="server" OnSelectedIndexChanged="gvFabricante_SelectedIndexChanged"></asp:GridView>
		</div>
		<div class="dados_fabricante" runat="server">
			<div class="campo_consul_fabr">
				Nome:
				<asp:TextBox runat="server" type="text" name="nome_fabr" class="input_nome_fabr_consul" ID="txtNomeFabr"></asp:TextBox>
			</div>
			<div class="campo_consul_fabr">
				Telefone:
				<asp:TextBox runat="server" type="text" name="telefone_fabr" class="input_tel_fabr_consul" ID="txtTelFabr"></asp:TextBox>
			</div>
			<div class="campo_consul_fabr">
				Cidade:
				<asp:TextBox runat="server" type="text" name="cidade_fabr" class="input_cidade_fabr_consul" ID="txtCidadeFabr"></asp:TextBox>
				UF:
				<select class="slc_uf_fabr_consul">
						<option value="1" runat="server">RO</option>
						<option value="2" runat="server">AC</option>
						<option value="3" runat="server">AM</option>
						<option value="4" runat="server">RR</option>
						<option value="5" runat="server">PA</option>
						<option value="6" runat="server">AP</option>
						<option value="7" runat="server">TO</option>
						<option value="8" runat="server">MA</option>
						<option value="9" runat="server">PI</option>
						<option value="10" runat="server">CE</option>
						<option value="11" runat="server">RN</option>
						<option value="12" runat="server">PB</option>
						<option value="13" runat="server">PE</option>
						<option value="14" runat="server">AL</option>
						<option value="15" runat="server">SE</option>
						<option value="16" runat="server">BA</option>
						<option value="17" runat="server">MG</option>
						<option value="18" runat="server">ES</option>
						<option value="19" runat="server">RJ</option>
						<option value="20" runat="server" selected="selected">SP</option>
						<option value="21" runat="server">PR</option>
						<option value="22" runat="server">SC</option>
						<option value="23" runat="server">RS</option>
						<option value="24" runat="server">MS</option>
						<option value="25" runat="server">MT</option>
						<option value="26" runat="server">GO</option>
						<option value="27" runat="server">DF</option>
				</select>
			</div>
			<br/><br/>
			<asp:Button runat="server" class="btn_consul_salvar" Text="Salvar alterações" ID="btnSalvar"></asp:Button>
			<asp:Button runat="server" class="btn_consul_editar" Text="Editar" ID="btnEditar"></asp:Button>
			<asp:Button runat="server" class="btn_consul_remover" Text="Excluir" ID="btnExcluir"></asp:Button>
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
