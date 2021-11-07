using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Ordem_servico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            List<ORCAMENTO> orcamento = con_bd.ORCAMENTO.ToList();
            gvOrdemServico.DataSource = orcamento;
            gvOrdemServico.DataBind();
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void gvOrdemServico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gvOrdemServico == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvOrdemServico != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    //string ID = gvOrdemServico.SelectedValue.ToString();
                    //ORCAMENTO orcamentoselecionado = con_bd.ORCAMENTO.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                }
            }
        }

        protected void btnConcluido_Click(object sender, EventArgs e)
        {

        }
    }
}