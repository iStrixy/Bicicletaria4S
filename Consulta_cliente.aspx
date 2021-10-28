<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta_cliente.aspx.cs" Inherits="PROJ_INTER_BC4S.Consulta_cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css"/>
    <title>Bicicletaria 4S - Consulta de cliente</title>
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
							<li><a href="#" class="tmenu">Consulta de cliente</a></li>
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
		<section id="titulo_consul_cliente">
			<p>Consulta de cliente</p>
		</section>
		<div>
			<asp:Label runat="server" ID="lblError"></asp:Label>
		</div>
		<br/>
		<div class="consul_cliente">
			<asp:GridView ID="gvCliente" runat="server" OnSelectedIndexChanged="gvCliente_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="ID">
                <Columns>
                    <asp:BoundField DataField="NOME" HeaderText="Nome" />
                    <asp:BoundField DataField="LOGRADOURO" HeaderText="Logradouro" />
                    <asp:BoundField DataField="NUM_LOGRADOURO" HeaderText="Num_logradouro" />
                    <asp:BoundField DataField="BAIRRO" HeaderText="Bairro" />
                    <asp:BoundField DataField="COMPLEMENTO" HeaderText="Complemento" />
                    <asp:BoundField DataField="CEP" HeaderText="CEP" />
                    <asp:BoundField DataField="CPF" HeaderText="CPF" />
                    <asp:BoundField DataField="EMAIL" HeaderText="E-mail" />
                    <asp:BoundField DataField="TELEFONE" HeaderText="Telefone" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
            </asp:GridView>
		</div>
		<br/>
			<div class="dados_cliente" runat="server">
				<div>
					<asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
				</div>
				<div class="campo_consul_cliente">
					Nome:
					<asp:TextBox runat="server" type="text" name="nome" class="input_nome_cliente_consul" ID="txtNomeCliente" Width="200px"></asp:TextBox>
				</div>
				<div class="campo_consul_cliente">
					Rua:
					<asp:TextBox runat="server" type="text" name="rua" class="input_rua_cliente_consul" ID="txtRuaCliente" Width="200px"></asp:TextBox>
				</div>
				<div class="campo_consul_cliente">
					Número:
					<asp:TextBox runat="server" type="text" name="numero" class="input_numero_cliente_consul" ID="txtNumeroCliente" Width="30px"></asp:TextBox>
					Bairro:
					<asp:TextBox runat="server" type="text" name="bairro" class="input_bairro_cliente_consul" ID="txtBairroCliente" Width="150px"></asp:TextBox>
				</div>
				<div class="campo_consul_cliente">
					Complemento:
					<asp:TextBox runat="server" type="text" name="complemento" class="input_complemento_cliente_consul" ID="txtComplementoCliente" Width="150px"></asp:TextBox>
				</div>
				<div class="campo_consul_cliente">
					CEP:
					<asp:TextBox runat="server" type="text" name="CEP" class="input_cep_cliente_consul" ID="txtCepCliente" Width="150px"></asp:TextBox>
				</div>
				<div class="campo_consul_cliente">
					CPF:
					<asp:TextBox runat="server" type="text" name="CPF" class="input_cpf_cliente_consul" ID="txtCpfCliente" Width="150px"></asp:TextBox>
				</div>
				<div class="campo_consul_cliente">
					E-mail:
					<asp:TextBox runat="server" type="text" name="email" class="input_email_cliente_consul" ID="txtEmailCliente" Width="150px"></asp:TextBox>
				</div>
				<div class="campo_consul_cliente">
					Telefone:
					<asp:TextBox runat="server" type="text" name="telefone" class="input_tel_cliente_consul" ID="txtTelCliente" Width="150px"></asp:TextBox>
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