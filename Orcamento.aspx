﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orcamento.aspx.cs" Inherits="PROJ_INTER_BC4S.Orcamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bicicletaria 4S - Orçamento</title>
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
							<li><a href="Cadastro_fabricante.aspx" class="tmenu">Cadastro de fabricante</a></li>
							<li><a href="Cadastro_fornecedor.aspx" class="tmenu">Cadastro de fornecedor</a></li>
						</ul>
					</li>
					<li class="has-submenu"><a href="#" class="tmenu">Orçamento</a>
						<ul>
							<li><a href="#" class="tmenu">Novo orçamento</a></li>
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
		<section id="titulo_orcamento">
			<p>Formulário de orçamento</p>
		</section>
		<br/><br/>
		<form method="post" class="form_orcamento" autocomplete="off">
			<div id="titulo_dados_orcamento">Dados cadastrais do cliente</div><br/>
			<div class="campos_orcamento" id="nome_cliente_orcamento">
				Nome do cliente: <select> </select>
			</div>
			<div class="campos_orcamento" id="rua_cliente_orcamento">
				Rua: <input type="text" name="endereco_cliente" class="input_endereco_cliente">
			</div>
			<div class="campos_orcamento" id="endereco_cliente_orcamento">
				Bairro: <input type="text" name="bairro_cliente" class="input_bairro_cliente">
				Número: <input type="text" name="numero_cliente" class="input_numero_cliente">
			</div>
			<div class="campos_orcamento" id="telefone_cliente_orcamento">
				Celular: <input type="text" name="celular_cliente" class="input_telefone_cliente">
			</div>
			<div class="campos_orcamento" id="cpf_cliente_orcamento">
				CPF: <input type="text" name="cpf_cliente" class="input_cpf_cliente">
			</div>
			<br/><br/>
			<div id="titulo_dados_orcamento">Orçamento de produtos</div><br/>
			<div class="campos_orcamento_produto" id="descricao_orcamento_produto">
				<table>
					<tr>
						<td id="t_head" class="tb_head">Item</td>
						<td class="tb_head">Descrição</td>
						<td class="tb_head">Quantidade</td>
						<td class="tb_head">Valor Unitário</td>
						<td class="tb_head">Subtotal</td>
					</tr>
					<tbody>
						<tr>
							<td><input class="inpt_orc" id="cod_input" type="text"></td>
							<td><input class="inpt_orc" id="desc_input" type="text"></td>
							<td><input class="inpt_orc" id="qtd_input" type="text"></td>
							<td><input class="inpt_orc" id="vunit_input" type="text"></td>
							<td><input class="inpt_orc" id="subt_input" type="text"></td>
						</tr>
						<tr>
							<td><input class="inpt_orc" id="cod_input" type="text"></td>
							<td><input class="inpt_orc" id="desc_input" type="text"></td>
							<td><input class="inpt_orc" id="qtd_input" type="text"></td>
							<td><input class="inpt_orc" id="vunit_input" type="text"></td>
							<td><input class="inpt_orc" id="subt_input" type="text"></td>
						</tr>
					</tbody>
				</table>
			</div>
			<br><br>
			<div id="titulo_dados_orcamento">Orçamento de serviços</div><br/>
			<div class="campos_orcamento_servicos" id="descricao_orcamento_servico">
				<table>
					<tr>
						<td id="t_head" class="tb_head">Item</td>
						<td class="tb_head">Descrição</td>
						<td class="tb_head">Subtotal</td>
					</tr>
					<tbody>
						<tr>
							<td><input class="inpt_orc" id="cod_input" type="text"></td>
							<td><input class="inpt_orc" id="desc_input" type="text"></td>
							<td><input class="inpt_orc" id="subt_input" type="text"></td>
						</tr>
						<tr>
							<td><input class="inpt_orc" id="cod_input" type="text"></td>
							<td><input class="inpt_orc" id="desc_input" type="text"></td>
							<td><input class="inpt_orc" id="subt_input" type="text"></td>
						</tr>
					</tbody>
				</table>
			</div>
			<br/>
			<div id="valor_total">Valor total: R$ 50,00</div>
			<br/><br/>
			<div id="titulo_dados_orcamento">Informações adicionais</div><br/>
			<div>Orçamento nº: </div>
			<div>Data:</div>
			<div>Assinatura do cliente: </div>
			<div>Assinatura do funcionário: </div>
			<br/><br/>
			<button class="enviar-orcamento">Confirmar orçamento</button>
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
			<p><a href="Quem_somos.aspx" style="text-decoration: none;" class="trodape">Quem somos</a></p>
		</div>
		<div class="topicos" id="topicos-contatos">
			<h3><b>Telefones para contato:</b></h3>
			<p>(17) 99724-3466</p>
			<p>(17) 3542-7605</p>
		</div>
	</footer>
</body>
</html>