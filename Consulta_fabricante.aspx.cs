using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
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
            if (gvFabricante.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvFabricante.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvFabricante.SelectedValue.ToString();
                    FABRICANTE fabricanteselecionado = con_bd.FABRICANTE.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.FABRICANTE.Remove(fabricanteselecionado);
                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Fabricante excluído com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (gvFabricante.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvFabricante.SelectedValue != null)
            {
                int ID = Convert.ToInt32(gvFabricante.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    FABRICANTE fabricante = con_bd.FABRICANTE.Where(linha => linha.ID == ID).FirstOrDefault();
                    if (fabricante != null)
                    {
                        txtNomeFabr.Text = fabricante.NOME;
                        txtTelFabr.Text = fabricante.TELEFONE.ToString();
                        txtCidadeFabr.Text = fabricante.CIDADE;
                        txtUfFabr.Text = fabricante.UF;
                        lblID.Text = fabricante.ID.ToString();
                    }
                }
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            double tel;
            string tel_max = txtTelFabr.Text;
            string uf_max = txtUfFabr.Text;
            string cidade = txtCidadeFabr.Text;

            if (gvFabricante.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (!Regex.IsMatch(txtCidadeFabr.Text, @"^[a-zA-Z-[\b]]+$"))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Cidade inválido!";
            }
            else if (!double.TryParse(txtTelFabr.Text, out tel))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (tel_max.Length < 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (tel_max.Length > 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (uf_max.Length < 2)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo UF inválido!";
            }
            else if (uf_max.Length > 2)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo UF inválido!";
            }
            else if (txtNomeFabr.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Nome vazio!";
            }
            else if (txtTelFabr.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone vazio!";
            }
            else if (txtCidadeFabr.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Cidade vazio!";
            }
            else if (txtUfFabr.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo UF vazio!";
            }
            else
            {
                lblError.Text = string.Empty;
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    FABRICANTE fabricante = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        fabricante = con_bd.FABRICANTE.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    fabricante.NOME = txtNomeFabr.Text;
                    fabricante.TELEFONE = txtTelFabr.Text;
                    fabricante.CIDADE = txtCidadeFabr.Text;
                    fabricante.UF = txtUfFabr.Text;

                    if (lblError.Text.Equals(string.Empty))
                    {
                        con_bd.Entry(fabricante);
                    }

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Dados do fabricante alterado com sucesso!";
                    limpar_campos();
                }
            }
        }

        protected void txtUfFabr_TextChanged(object sender, EventArgs e)
        {
            txtUfFabr.Text = txtUfFabr.Text.ToUpper();
        }
    }
}