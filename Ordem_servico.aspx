<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ordem_servico.aspx.cs" Inherits="PROJ_INTER_BC4S.Ordem_servico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="styles/Folhaestilo.css" />
    <title>Bicicletaria 4S - Ordem de serviço</title>
</head>

<body>
    <form id="form1" runat="server">
        <div class="menu" id="topo">
            <header>
                <div class="logo">
                    <a href="Index.aspx">
                        <img src="Imagens/Logotipo.png" alt="logotipo_site" />
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
                                <li><a href="#" class="tmenu">Ordem de serviço</a></li>
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
                        <li id="logout">
                            <asp:LinkButton ID="lb_sair" runat="server" OnClick="lb_sair_Click">Sair</asp:LinkButton></li>
                    </ul>
                    <asp:Label ID="lblNome" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblFunc" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblValor" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblIDc" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblServico" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblProduto" runat="server" Visible="false"></asp:Label>
                    <asp:Label ID="lblData" runat="server" Visible="false"></asp:Label>
                </nav>
            </header>
        </div>
        <div class="corpo">
            <section id="titulo_consul_ordem_serv">
                <p>Ordem de serviço</p>
            </section>
            <div>
                <asp:Label runat="server" ID="lblError"></asp:Label>
            </div>
            <div class="consul_ordem_serv">
                <asp:GridView class="GridV" ID="gvOrdemServico" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="Orçamento" />
                        <asp:BoundField DataField="PESSOA.NOME" HeaderText="Nome do cliente" />
                        <asp:BoundField DataField="LOGIN.NOME_FUNCIONARIO" HeaderText="Nome do funcionário" />
                        <asp:BoundField DataField="DATA_ORC" HeaderText="Data" />
                        <asp:BoundField DataField="VALOR_TOTAL" HeaderText="Valor Total" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle Font-Bold="True" ForeColor="#525252"/>
                </asp:GridView>
            </div>
            <br />
            <div class="dados_ordem_servico" runat="server">
                <div>
                    <asp:Label runat="server" ID="lblID" Visible="false"></asp:Label>
                </div>
                <div class="btn">
                    <asp:Button runat="server" class="btn_consul_imprimir" Text="Imprimir orçamento" ID="btnImprimir" OnClick="btnImprimir_Click"></asp:Button>
                    <asp:Button runat="server" class="btn_ordem_excluir" Text="Excluir" ID="btnExcluir" OnClick="btnExcluir_Click"></asp:Button>
                </div>
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
