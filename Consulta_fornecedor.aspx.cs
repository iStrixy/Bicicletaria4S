using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace PROJ_INTER_BC4S
{
    public partial class Consulta_fornecedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            String nomeuserlogado = (String)Session["userlogado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("TeladeLogin.aspx");
            }
            else if (!IsPostBack)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    carregarGrid(con_bd);
                }
            }
        }

        private void carregarGrid(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<FORNECEDOR> fornecedor = con_bd.FORNECEDOR.ToList();
            gvFornecedor.DataSource = fornecedor;
            gvFornecedor.DataBind();
        }

        private void limpar_campos()
        {
            txtNomeForn.Text = string.Empty;
            txtTelForn.Text = string.Empty;
            txtCidadeForn.Text = string.Empty;
            txtUfForn.Text = string.Empty;
            txtEmailForn.Text = string.Empty;
        }

        protected void gvFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if(gvFornecedor.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvFornecedor.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvFornecedor.SelectedValue.ToString();
                    FORNECEDOR fornecedorselecionado = con_bd.FORNECEDOR.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.FORNECEDOR.Remove(fornecedorselecionado);
                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Fornecedor excluído com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (gvFornecedor.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvFornecedor.SelectedValue != null)
            {
                int ID = Convert.ToInt32(gvFornecedor.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    FORNECEDOR fornecedor = con_bd.FORNECEDOR.Where(linha => linha.ID == ID).FirstOrDefault();
                    if (fornecedor != null)
                    {
                        txtNomeForn.Text = fornecedor.NOME;
                        txtTelForn.Text = fornecedor.TELEFONE.ToString();
                        txtCidadeForn.Text = fornecedor.CIDADE.ToString();
                        txtUfForn.Text = fornecedor.UF.ToString();
                        txtEmailForn.Text = fornecedor.EMAIL.ToString();
                        lblID.Text = fornecedor.ID.ToString();
                    }
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            double tel;
            string UF = txtUfForn.Text;
            string tel_max = txtTelForn.Text;
            string cidade = txtCidadeForn.Text;

            if (gvFornecedor.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (!Regex.IsMatch(txtCidadeForn.Text, @"^[a-zA-Z]+$"))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Cidade inválido!";
            }
            else if (!double.TryParse(txtTelForn.Text, out tel))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (tel_max.Length < 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (tel_max.Length > 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (UF.Length > 2)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo UF inválido!";
            }
            else if (UF.Length < 2)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo UF inválido!";
            }
            else if (txtNomeForn.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Nome vazio!";
            }
            else if (txtTelForn.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone vazio!";
            }
            else if (txtCidadeForn.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Cidade vazio!";
            }
            else if (txtUfForn.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo UF vazio!";
            }
            else if (txtEmailForn.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo E-mail vazio!";
            }
            else
            {
                lblError.Text = string.Empty;
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    FORNECEDOR fornecedor = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        fornecedor = con_bd.FORNECEDOR.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    fornecedor.NOME = txtNomeForn.Text;
                    fornecedor.TELEFONE = txtTelForn.Text;
                    fornecedor.CIDADE = txtCidadeForn.Text;
                    fornecedor.UF = txtUfForn.Text;
                    fornecedor.EMAIL = txtEmailForn.Text;

                    if (lblError.Text.Equals(string.Empty))
                    {
                        con_bd.Entry(fornecedor);
                    }

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Dados do fornecedor alterado com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void txtUfForn_TextChanged(object sender, EventArgs e)
        {
            txtUfForn.Text = txtUfForn.Text.ToUpper();
        }
    }
}