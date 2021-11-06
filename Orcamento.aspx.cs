using System;
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
            //lblIDProduto.Text = string.Empty;
            ddlProduto.SelectedIndex = 0;
            //txtQuantidadeProduto.Text = string.Empty;
            //lblVlrUni.Text = string.Empty;
            //lblSubtPd.Text = string.Empty;
        }

        private void limpar_campos_servico()
        {
            //lblIDServico.Text = string.Empty;
            ddlServico.SelectedIndex = 0;
            //lblSubtSv.Text = string.Empty;
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

        protected void btnConfirmOrc_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (ddlPessoa.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Cliente!";
            }
            else
            {
              
            }
        }

    }

}