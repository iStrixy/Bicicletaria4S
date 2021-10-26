using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Cadastro_fornecedor : System.Web.UI.Page
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

        protected void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            txtTelefoneFornecedor.MaxLength = 11;
        }

        protected void txtEmailFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCidadeFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTelefoneFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNomeFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void txtUfFornecedor_TextChanged(object sender, EventArgs e)
        {
            txtUfFornecedor.Text = txtUfFornecedor.Text.ToUpper();
        }
    }
}