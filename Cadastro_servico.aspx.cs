using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Cadastro_servico : System.Web.UI.Page
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
            txtDescricaoServico.Text = String.Empty;
            txtValorServico.Text = String.Empty;
        }
        protected void btnCadastrarServico_Click(object sender, EventArgs e)
        {
            double vlr_unit;
            if (!double.TryParse(txtValorServico.Text, out vlr_unit))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else if(txtDescricaoServico.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Inserir informações no campo Descrição!";
            }
            else if(txtValorServico.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Valor inválido!";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Serviço cadastrado com sucesso!";
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    SERVICO cad_servico = new SERVICO();
                    cad_servico.DESCRICAO = txtDescricaoServico.Text;
                    cad_servico.VALOR = Convert.ToDouble(txtValorServico.Text);

                    con_bd.SERVICO.Add(cad_servico);
                    con_bd.SaveChanges();
                    limpar_campos();
                }
            }
        }

        protected void txtValorServico_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtDescricaoServico_TextChanged(object sender, EventArgs e)
        {

        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }
    }
}