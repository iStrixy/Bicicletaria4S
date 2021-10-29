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

        }
        protected void btnCadastrarFabricante_Click(object sender, EventArgs e)
        {
            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
            {
                double tel;
                string tel_max = txtTelefoneFabricante.Text;

                if (!double.TryParse(txtTelefoneFabricante.Text, out tel))
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
                else if (txtNomeFabricante.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Nome vazio!";
                }
                else if (txtTelefoneFabricante.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone vazio!";
                }
                else if (txtCidadeFabricante.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Cidade vazio!";
                }
                else if (DpUF.SelectedValue.ToString() == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo UF vazio!!";
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Fabricante cadastrado com sucesso!";

                    FABRICANTE cad_fabricante = new FABRICANTE();
                    cad_fabricante.NOME = txtNomeFabricante.Text;
                    cad_fabricante.TELEFONE = txtTelefoneFabricante.Text;
                    cad_fabricante.CIDADE = txtCidadeFabricante.Text;
                    cad_fabricante.UF = DpUF.SelectedValue.ToString();

                    con_bd.FABRICANTE.Add(cad_fabricante);
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

    }
}