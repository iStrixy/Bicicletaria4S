using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Cadastro_fabricante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String nomeuserlogado = (String)Session["userlogado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("TeladeLogin.aspx");
            }
            lblError.Text = String.Empty;
        }

        private void limpar_campos()
        {
            txtNomeFabricante.Text = String.Empty;
            txtTelefoneFabricante.Text = String.Empty;
            txtCidadeFabricante.Text = String.Empty;
            txtUfFabricante.Text = String.Empty;
        }
        protected void btnCadastrarFabricante_Click(object sender, EventArgs e)
        {
            txtTelefoneFabricante.MaxLength = 10;
            int tel = 0;
            if (!int.TryParse(txtTelefoneFabricante.Text, out tel))
            {
                lblError.Text = "Campo telefone inválido!";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Usuário cadastrado com sucesso!";
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    FABRICANTE cad_fabricante = new FABRICANTE();
                    cad_fabricante.NOME = txtNomeFabricante.Text;
                    cad_fabricante.TELEFONE = Convert.ToInt32(txtTelefoneFabricante.Text);
                    cad_fabricante.CIDADE = txtCidadeFabricante.Text;
                    cad_fabricante.UF = txtUfFabricante.Text;

                    con_bd.FABRICANTE.Add(cad_fabricante);
                    con_bd.SaveChanges();
                    limpar_campos();
                }
            }
        }

        protected void txtNomeFabricante_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTelefoneFabricante_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCidadeFabricante_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void txtUfFabricante_TextChanged(object sender, EventArgs e)
        {
            txtUfFabricante.Text = txtUfFabricante.Text.ToUpper();
        }
    }
}