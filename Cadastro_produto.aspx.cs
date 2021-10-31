using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Cadastro_produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;
            String nomeuserlogado = (String)Session["userlogado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("TeladeLogin.aspx");
            }
            else if (!IsPostBack)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    carregarFabricante(con_bd);
                    carregarFornecedor(con_bd);
                }
            }
        }

        private void limpar_campos()
        {
            txtDescricaoProduto.Text = string.Empty;
            txtValorUniProduto.Text = string.Empty;
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
            ddlFabricante.Items.Insert(0, "Selecionar...");
        }

        private void carregarFornecedor(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<FORNECEDOR> fornecedor = con_bd.FORNECEDOR.OrderBy(linha => linha.NOME).ToList();
            ddlFornecedor.DataSource = fornecedor;
            ddlFornecedor.DataTextField = "NOME";
            ddlFornecedor.DataValueField = "ID";
            ddlFornecedor.DataBind();
            ddlFornecedor.Items.Insert(0, "Selecionar...");
        }

        protected void txtDescricaoProduto_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtValorUniProduto_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            double vlr_unit;

            if (!double.TryParse(txtValorUniProduto.Text, out vlr_unit))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else if (txtDescricaoProduto.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Descrição vazio!";
            }
            else if (txtValorUniProduto.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Valor vazio!";
            }
            else if (ddlFabricante.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Fabricante!";
            }
            else if (ddlFornecedor.SelectedValue.ToString() == "Selecionar...")
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione o Fornecedor!";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Produto cadastrado com sucesso!";
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PRODUTO cad_produto = new PRODUTO();
                    cad_produto.DESCRICAO = txtDescricaoProduto.Text;
                    cad_produto.VALOR = Convert.ToDouble(txtValorUniProduto.Text);
                    cad_produto.ID_FABRICANTE = Convert.ToInt32(ddlFabricante.SelectedValue.ToString());
                    cad_produto.ID_FORNECEDOR = Convert.ToInt32(ddlFornecedor.SelectedValue.ToString());

                    con_bd.PRODUTO.Add(cad_produto);
                    con_bd.SaveChanges();
                    limpar_campos();
                }
            }
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void ddlFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}