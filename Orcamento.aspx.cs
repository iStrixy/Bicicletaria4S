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
            if(ddlPessoa.SelectedValue.ToString() == "Selecionar...")
            {
                txtRuaCli.Text = string.Empty;
                txtNumeroCli.Text = string.Empty;
                txtBairroCli.Text = string.Empty;
                txtTelCli.Text = string.Empty;
                txtCpfCli.Text = string.Empty;
            }
            else if (ddlPessoa.SelectedIndex != 0)
            {
                txtCpfCli.Text = "asd0";
                int ID = Convert.ToInt32(ddlPessoa.SelectedValue.ToString());
                {
                    PESSOA pessoaselecionada = con_bd.PESSOA.Where(linha => linha.ID == ID).FirstOrDefault();
                    if(pessoaselecionada != null)
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

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }
    }
}