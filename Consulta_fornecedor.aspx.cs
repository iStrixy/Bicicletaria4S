using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if(gvFornecedor.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvFornecedor.SelectedValue.ToString();
                    FORNECEDOR fornecedorselecionado = con_bd.FORNECEDOR.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.FORNECEDOR.Remove(fornecedorselecionado);
                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Item excluído com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }
    }
}