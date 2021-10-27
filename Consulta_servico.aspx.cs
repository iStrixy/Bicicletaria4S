using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Consulta_servico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;
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

        private void carregarGrid (BD_BICICLETARIA_4SEntities con_bd)
        {
            List<SERVICO> servico = con_bd.SERVICO.ToList();
            gvServico.DataSource = servico;
            gvServico.DataBind();
        }

        private void limpar_campos()
        {
            txtDescricaoServico.Text = String.Empty;
            txtValorServico.Text = String.Empty;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;
            double vlr_unit;
            if (!double.TryParse(txtValorServico.Text, out vlr_unit))
            {
                lblError.Text = "Valor inválido!";
            }
            else if (txtDescricaoServico.Text == String.Empty)
            {
                lblError.Text = "Insira as informações no campo descrição";
            }
            else if (txtValorServico.Text == String.Empty)
            {
                lblError.Text = "Insira as informações no campo valor";
            }
            else
            {
                vlr_unit = Convert.ToDouble(txtValorServico.Text);

                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    SERVICO servico = null;
                    if (lblError.Text == null)
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        servico = con_bd.SERVICO.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    servico.VALOR = vlr_unit;
                    servico.DESCRICAO = txtDescricaoServico.Text;

                    if (lblError.Text == null)
                    {
                        con_bd.Entry(servico);
                    }

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Dados alterados com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if(gvServico.SelectedValue != null)
            {
                lblError.Text = String.Empty;
                int ID = Convert.ToInt32(gvServico.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    SERVICO servico = con_bd.SERVICO.Where(linha => linha.ID == ID).FirstOrDefault();
                    if(servico != null)
                    {
                        txtDescricaoServico.Text = servico.DESCRICAO;
                        txtValorServico.Text = servico.VALOR.ToString();
                    }
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if(gvServico.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvServico.SelectedValue.ToString();
                    SERVICO servicoselecionado = con_bd.SERVICO.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.SERVICO.Remove(servicoselecionado);
                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Item excluído com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }
    }
}