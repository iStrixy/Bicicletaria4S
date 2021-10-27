using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Consulta_fabricante : System.Web.UI.Page
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
                }
            }
        }

        private void carregarGrid(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<FABRICANTE> fabricante = con_bd.FABRICANTE.ToList();
            gvFabricante.DataSource = fabricante;
            gvFabricante.DataBind();
        }

        private void limpar_campos()
        {
            txtNomeFabr.Text = string.Empty;
            txtTelFabr.Text = string.Empty;
            txtCidadeFabr.Text = string.Empty;
            txtUfFabr.Text = string.Empty;
        }

        protected void gvFabricante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gvFabricante.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvFabricante.SelectedValue.ToString();
                    FABRICANTE fabricanteselecionado = con_bd.FABRICANTE.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.FABRICANTE.Remove(fabricanteselecionado);
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
            if(gvFabricante.SelectedValue != null)
            {
                lblError.Text = string.Empty;
                int ID = Convert.ToInt32(gvFabricante.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    FABRICANTE fabricante = con_bd.FABRICANTE.Where(linha => linha.ID == ID).FirstOrDefault();
                    if(fabricante != null)
                    {
                        txtNomeFabr.Text = fabricante.NOME;
                        txtTelFabr.Text = fabricante.TELEFONE.ToString();
                        txtCidadeFabr.Text = fabricante.CIDADE;
                        txtUfFabr.Text = fabricante.UF;
                    }
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void txtUfFabr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}