﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Orcamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtRuaCli.Enabled = false;
            txtNumeroCli.Enabled = false;
            txtBairroCli.Enabled = false;
            txtTelCli.Enabled = false;
            txtCpfCli.Enabled = false;
            String nomeuserlogado = (String)Session["userlogado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("TeladeLogin.aspx");
            }
            else if (!IsPostBack)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    carregarPessoa(con_bd);
                    carregarProduto(con_bd);
                    carregarServico(con_bd);
                    carregarFuncionario(con_bd);
                }
            }
        }
        private void carregarPessoa(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<PESSOA> pessoa = con_bd.PESSOA.OrderBy(linha => linha.NOME).ToList();
            ddlPessoa.DataSource = pessoa;
            ddlPessoa.DataTextField = "NOME";
            ddlPessoa.DataValueField = "ID";
            ddlPessoa.DataBind();
            ddlPessoa.Items.Insert(0, "Selecionar...");
        }

        private void carregarProduto(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<PRODUTO> produto = con_bd.PRODUTO.OrderBy(linha => linha.DESCRICAO).ToList();
            ddlProduto.DataSource = produto;
            ddlProduto.DataTextField = "DESCRICAO";
            ddlProduto.DataValueField = "ID";
            ddlProduto.DataBind();
            ddlProduto.Items.Insert(0, "Selecionar...");
        }

        private void carregarServico(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<SERVICO> servico = con_bd.SERVICO.OrderBy(linha => linha.DESCRICAO).ToList();
            ddlServico.DataSource = servico;
            ddlServico.DataTextField = "DESCRICAO";
            ddlServico.DataValueField = "ID";
            ddlServico.DataBind();
            ddlServico.Items.Insert(0, "Selecionar...");
        }

        private void carregarFuncionario(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<LOGIN> funcionario = con_bd.LOGIN.OrderBy(linha => linha.NOME_FUNCIONARIO).ToList();
            ddlFuncionario.DataSource = funcionario;
            ddlFuncionario.DataTextField = "NOME_FUNCIONARIO";
            ddlFuncionario.DataValueField = "ID";
            ddlFuncionario.DataBind();
            ddlFuncionario.Items.Insert(0, "Selecionar...");
        }

        private void carregarGridProduto(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<PROD_ORCAMENTO> list_prod = con_bd.PROD_ORCAMENTO.Where(linha => linha.ID_ORCAMENTO.ToString().Equals(lblIDOrc.Text)).ToList();
            gvProduto.DataSource = list_prod;
            gvProduto.DataBind();
        }

        private void carregarGridServico(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<REG_SERV_ORCAMENTO> list_serv = con_bd.REG_SERV_ORCAMENTO.Where(linha => linha.ID_ORCAMENTO.ToString().Equals(lblIDOrc.Text)).ToList();
            gvServico.DataSource = list_serv;
            gvServico.DataBind();
        }

        private void limpar_campos_pessoa()
        {
            txtRuaCli.Text = string.Empty;
            txtNumeroCli.Text = string.Empty;
            txtBairroCli.Text = string.Empty;
            txtTelCli.Text = string.Empty;
            txtCpfCli.Text = string.Empty;
            ddlPessoa.SelectedIndex = 0;
        }

        private void limpar_campos_produto()
        {
            lblIDProduto.Text = string.Empty;
            ddlProduto.SelectedIndex = 0;
            txtQuantidadeProduto.Text = string.Empty;
            lblVlrUni.Text = string.Empty;
            lblSubtPd.Text = string.Empty;
            lblNomeProduto.Text = string.Empty;
            lblQtdProduto.Text = string.Empty;
        }

        private void limpar_campos_servico()
        {
            lblIDServico.Text = string.Empty;
            ddlServico.SelectedIndex = 0;
            lblSubtSv.Text = string.Empty;
            lblDescSv.Text = string.Empty;
        }

        private void limpar_campos_funcionario()
        {
            ddlFuncionario.SelectedIndex = 0;
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void ddlPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
            {

                if (ddlPessoa.SelectedValue.ToString() == "Selecionar...")
                {
                    limpar_campos_pessoa();
                }
                else if (ddlPessoa.SelectedIndex != 0)
                {
                    int ID = Convert.ToInt32(ddlPessoa.SelectedValue.ToString());
                    {
                        PESSOA pessoaselecionada = con_bd.PESSOA.Where(linha => linha.ID == ID).FirstOrDefault();
                        if (pessoaselecionada != null)
                        {
                            txtRuaCli.Text = pessoaselecionada.LOGRADOURO;
                            txtNumeroCli.Text = pessoaselecionada.NUM_LOGRADOURO.ToString();
                            txtBairroCli.Text = pessoaselecionada.BAIRRO;
                            txtTelCli.Text = pessoaselecionada.TELEFONE.ToString();
                            txtCpfCli.Text = pessoaselecionada.CPF.ToString();
                        }
                    }
                }
            }
        }

        protected void btnNewOrc_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (ddlPessoa.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Cliente!";
            }
            else if (ddlFuncionario.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Funcionário!";
            }
            else
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    ORCAMENTO cad_orcamento = new ORCAMENTO();
                    cad_orcamento.ID_CLIENTE = Convert.ToInt32(ddlPessoa.SelectedValue.ToString());
                    cad_orcamento.ID_FUNCIONARIO = Convert.ToInt32(ddlFuncionario.SelectedValue.ToString());
                    cad_orcamento.VALOR_TOTAL = Convert.ToDouble("0");

                    con_bd.ORCAMENTO.Add(cad_orcamento);
                    con_bd.SaveChanges();

                    lblIDOrc.Text = cad_orcamento.ID.ToString();
                    lblValorTotal.Text = cad_orcamento.VALOR_TOTAL.ToString();
                    btnNewOrc.Enabled = false;
                    DateTime dataatual = DateTime.Now;
                    lblDataAtual.Text = dataatual.ToString("dd/MM/yyyy");
                }
            }
        }
        protected void btnConfirmOrc_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (lblIDOrc.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Registro de novo orçamento não realizado, aperte o botão 'Novo orçamento'"; 
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = string.Empty;
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    ORCAMENTO orcamento = null;
                    if(lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblIDOrc.Text);
                        orcamento = con_bd.ORCAMENTO.Where(linha7 => linha7.ID.Equals(ID)).FirstOrDefault();
                    }

                    double s1;
                    double s2;
                    double st;
                    s1 = Convert.ToDouble(lblSubtotalPd.Text);
                    s2 = Convert.ToDouble(lblSubtotalSv.Text);
                    st = s1 + s2;

                    lblValorTotal.Text = Convert.ToString(st);

                    orcamento.VALOR_TOTAL = st;

                    if (lblError.Text.Equals(string.Empty))
                    {
                        con_bd.Entry(orcamento);
                    }

                    con_bd.SaveChanges();
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Orçamento cadastrado com sucesso!";

                    limpar_campos_pessoa();
                    limpar_campos_funcionario();
                    limpar_campos_produto();
                    limpar_campos_servico();
                    gvProduto.DataSource = null;
                    gvProduto.DataBind();
                    gvServico.DataSource = null;
                    gvServico.DataBind();
                    lblValorTotal.Text = string.Empty;
                    lblSubtotalPd.Text = string.Empty;
                    lblSubtotalSv.Text = string.Empty;
                    lblDataAtual.Text = string.Empty;
                    lblIDOrc.Text = string.Empty;
                    btnNewOrc.Enabled = true;
                }
            }
        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (lblIDOrc.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Registro de novo orçamento não realizado, aperte o botão 'Novo orçamento'";
            }
            else if (txtQuantidadeProduto.Text.ToString() == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Insira uma quantidade!";
            }
            else if(Convert.ToInt32(txtQuantidadeProduto.Text) <= 0)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    int ID = Convert.ToInt32(ddlProduto.SelectedValue.ToString());
                    {
                        PRODUTO produtoselecionado = con_bd.PRODUTO.Where(linha1 => linha1.ID == ID).FirstOrDefault();

                        double quantidade, vlrunit, subtotalpd;
                        quantidade = Convert.ToDouble(txtQuantidadeProduto.Text);
                        vlrunit = Convert.ToDouble(produtoselecionado.VALOR.ToString());
                        subtotalpd = (vlrunit * quantidade);

                        if (produtoselecionado != null)
                        {
                            lblIDProduto.Text = produtoselecionado.ID.ToString();
                            lblNomeProduto.Text = produtoselecionado.DESCRICAO;
                            lblQtdProduto.Text = txtQuantidadeProduto.Text.ToString();
                            lblVlrUni.Text = produtoselecionado.VALOR.ToString();
                            lblSubtPd.Text = Convert.ToString(subtotalpd);
                        }

                        PROD_ORCAMENTO cad_prod_orc = new PROD_ORCAMENTO();
                        cad_prod_orc.ID_ORCAMENTO = Convert.ToInt32(lblIDOrc.Text);
                        cad_prod_orc.ID_PRODUTO = Convert.ToInt32(lblIDProduto.Text);
                        cad_prod_orc.SUB_TOTAL = Convert.ToDouble(lblSubtPd.Text);

                        con_bd.PROD_ORCAMENTO.Add(cad_prod_orc);
                        con_bd.SaveChanges();

                        carregarGridProduto(con_bd);

                        var items = con_bd.PROD_ORCAMENTO.Where(linha => linha.ID_ORCAMENTO.ToString().Equals(lblIDOrc.Text)).ToList();
                        double total = 0;
                        foreach(PROD_ORCAMENTO pd in items)
                        {
                            total += pd.SUB_TOTAL;
                        }

                        ORCAMENTO orc = con_bd.ORCAMENTO.First(linha => linha.ID.ToString().Equals(lblIDOrc.Text));
                        orc.VALOR_TOTAL = total;
                        con_bd.Entry(orc);
                        con_bd.SaveChanges();
                        lblSubtotalPd.Text = Convert.ToString(total);
                    }
                }
            }
        }

        protected void lblCadastrarServico_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (lblIDOrc.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Registro de novo orçamento não realizado, aperte o botão 'Novo orçamento'";
            }
            else
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    int ID = Convert.ToInt32(ddlServico.SelectedValue.ToString());
                    {
                        SERVICO servicoselecionado = con_bd.SERVICO.Where(linha2 => linha2.ID == ID).FirstOrDefault();

                        if (servicoselecionado != null)
                        {
                            lblIDServico.Text = servicoselecionado.ID.ToString();
                            lblDescSv.Text = servicoselecionado.DESCRICAO;
                            lblSubtSv.Text = servicoselecionado.VALOR.ToString();
                        }

                        REG_SERV_ORCAMENTO cad_serv = new REG_SERV_ORCAMENTO();
                        cad_serv.ID_ORCAMENTO = Convert.ToInt32(lblIDOrc.Text);
                        cad_serv.ID_SERVICO = Convert.ToInt32(lblIDServico.Text);
                        cad_serv.SUB_TOTAL = Convert.ToDouble(lblSubtSv.Text);

                        con_bd.REG_SERV_ORCAMENTO.Add(cad_serv);
                        con_bd.SaveChanges();

                        carregarGridServico(con_bd);

                        var items = con_bd.REG_SERV_ORCAMENTO.Where(linha => linha.ID_ORCAMENTO.ToString().Equals(lblIDOrc.Text)).ToList();
                        double totalsv = 0;
                        foreach(REG_SERV_ORCAMENTO sv in items)
                        {
                            totalsv += sv.SUB_TOTAL;
                        }

                        ORCAMENTO orc = con_bd.ORCAMENTO.First(linha => linha.ID.ToString().Equals(lblIDOrc.Text));
                        orc.VALOR_TOTAL = totalsv;
                        con_bd.Entry(orc);
                        con_bd.SaveChanges();

                        lblSubtotalSv.Text = Convert.ToString(totalsv);
                    }
                }
            }
        }

        protected void gvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}