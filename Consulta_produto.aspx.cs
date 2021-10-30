using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Consulta_produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            String nomeuserlogado = (String)Session["userlogado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("TeladeLogin.aspx");
            }
            else if(!IsPostBack)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    carregarGrid(con_bd);
                    carregarFabricante(con_bd);
                    carregarFornecedor(con_bd);
                }
            }
        }

        private void carregarGrid(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<PRODUTO> produto = con_bd.PRODUTO.ToList();
            gvProduto.DataSource = produto;
            gvProduto.DataBind();
        }

        private void limpar_campos()
        {
            txtDescProd.Text = string.Empty;
            txtVlrUni.Text = string.Empty;
            ddlFabricante.SelectedIndex = 0;
            ddlFornecedor.SelectedIndex = 0;
        }

        private void carregarFabricante(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<FABRICANTE> fabricante = con_bd.FABRICANTE.OrderBy(linha => linha.NOME).ToList();
            ddlFabricante.DataSource = fabricante;
            ddlFabricante.DataTextField = "NOME";
            ddlFabricante.DataValueField = "ID";
            ddlFabricante.DataBind();
            ddlFabricante.Items.Insert(0, "");
        }

        private void carregarFornecedor(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<FORNECEDOR> fornecedor = con_bd.FORNECEDOR.OrderBy(linha => linha.NOME).ToList();
            ddlFornecedor.DataSource = fornecedor;
            ddlFornecedor.DataTextField = "NOME";
            ddlFornecedor.DataValueField = "ID";
            ddlFornecedor.DataBind();
            ddlFornecedor.Items.Insert(0, "");
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void txtVlrUni_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void BtnExcluir_Click(object sender, EventArgs e)
        {
            if(gvProduto.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if(gvProduto.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvProduto.SelectedValue.ToString();
                    PRODUTO produtoselecionado = con_bd.PRODUTO.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.PRODUTO.Remove(produtoselecionado);
                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Produto excluído com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            if (gvProduto.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvProduto.SelectedValue != null)
            {
                int ID = Convert.ToInt32(gvProduto.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PRODUTO produto = con_bd.PRODUTO.Where(linha => linha.ID == ID).FirstOrDefault();
                    if(produto != null)
                    {
                        txtDescProd.Text = produto.DESCRICAO;
                        txtVlrUni.Text = produto.VALOR.ToString("C");
                        ddlFornecedor.SelectedValue = produto.ID_FORNECEDOR.ToString();
                        ddlFabricante.SelectedValue = produto.ID_FABRICANTE.ToString();
                        lblID.Text = produto.ID.ToString();
                    }
                }
            }
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            double vlr_unit;

            if (gvProduto.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (!double.TryParse(txtVlrUni.Text, out vlr_unit))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else if (txtDescProd.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Descrição vazio!";
            }
            else if (txtVlrUni.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Valor vazio!";
            }
            else if (ddlFabricante.SelectedValue.ToString() == "")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Fabricante!";
            }
            else if (ddlFornecedor.SelectedValue.ToString() == "")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Fornecedor!";
            }
            else
            {
                lblError.Text = string.Empty;
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PRODUTO produto = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        produto = con_bd.PRODUTO.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    produto.DESCRICAO = txtDescProd.Text;
                    produto.VALOR = Convert.ToDouble(txtVlrUni.Text);
                    produto.ID_FABRICANTE = Convert.ToInt32(ddlFabricante.SelectedValue.ToString());
                    produto.ID_FORNECEDOR = Convert.ToInt32(ddlFornecedor.SelectedValue.ToString());

                    if (lblError.Text.Equals(string.Empty))
                    {
                        con_bd.Entry(produto);
                    }

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Dados do produto alterado com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void GvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if(gvProduto.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if(gvProduto.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvProduto.SelectedValue.ToString();
                    PRODUTO produtoselecionado = con_bd.PRODUTO.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.PRODUTO.Remove(produtoselecionado);
                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Produto excluído com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (gvProduto.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvProduto.SelectedValue != null)
            {
                int ID = Convert.ToInt32(gvProduto.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PRODUTO produto = con_bd.PRODUTO.Where(linha => linha.ID == ID).FirstOrDefault();
                    if(produto != null)
                    {
                        txtDescProd.Text = produto.DESCRICAO;
                        txtVlrUni.Text = produto.VALOR.ToString();
                        ddlFornecedor.SelectedValue = produto.ID_FORNECEDOR.ToString();
                        ddlFabricante.SelectedValue = produto.ID_FABRICANTE.ToString();
                        lblID.Text = produto.ID.ToString();
                    }
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            double vlr_unit;
            if (gvProduto.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (!double.TryParse(txtVlrUni.Text, out vlr_unit))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else if (txtDescProd.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Descrição vazio!";
            }
            else if (txtVlrUni.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Valor vazio!";
            }
            else if (ddlFabricante.SelectedValue.ToString() == "")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Fabricante!";
            }
            else if (ddlFornecedor.SelectedValue.ToString() == "")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Fornecedor!";
            }
            else
            {
                lblError.Text = string.Empty;
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PRODUTO produto = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        produto = con_bd.PRODUTO.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    produto.DESCRICAO = txtDescProd.Text;
                    produto.VALOR = Convert.ToDouble(txtVlrUni.Text);
                    produto.ID_FABRICANTE = Convert.ToInt32(ddlFabricante.SelectedValue.ToString());
                    produto.ID_FORNECEDOR = Convert.ToInt32(ddlFornecedor.SelectedValue.ToString());

                    if (lblError.Text.Equals(string.Empty))
                    {
                        con_bd.Entry(produto);
                    }

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Dados do produto alterado com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void gvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}