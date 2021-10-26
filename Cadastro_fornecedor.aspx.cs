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
        }

        protected void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())

            {
                FORNECEDOR cad_fornecedor = new FORNECEDOR();
                TELEFONE_FORNECEDOR telefone = new TELEFONE_FORNECEDOR();

                cad_fornecedor.NOME = txtNomeFornecedor.Text;
                cad_fornecedor.CIDADE = txtCidadeFornecedor.Text;
                //cad_fornecedor.UF = slcEstadoFabricante.ToString();
                telefone.TELEFONE = Convert.ToInt32(txtTelefoneFornecedor.Text);

                con_bd.FORNECEDOR.Add(cad_fornecedor);
                con_bd.SaveChanges();

            }
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
    }
}