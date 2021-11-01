using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

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

        private void limpar_campos()
        {
            txtCidadeFornecedor.Text = string.Empty;
            txtEmailFornecedor.Text = string.Empty;
            txtNomeFornecedor.Text = string.Empty;
            txtTelefoneFornecedor.Text = string.Empty;
            DpUF.SelectedValue = "Selecionar...";
        }

        protected void btnCadastrarFornecedor_Click(object sender, EventArgs e)
        {
            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
            {
                double tel;
                string tel_max = txtTelefoneFornecedor.Text;
                string cidade = txtCidadeFornecedor.Text;

                /* Nome */
                if (txtNomeFornecedor.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Nome vazio!";
                }
                else if (!Regex.IsMatch(txtNomeFornecedor.Text, @"[^0-9]+$"))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Nome inválido!";
                }
                /* Telefone */
                else if (txtTelefoneFornecedor.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone vazio!";
                }
                else if (!double.TryParse(txtTelefoneFornecedor.Text, out tel))
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
                /* Cidade */
                else if (txtCidadeFornecedor.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Cidade vazio!";
                }
                else if (!Regex.IsMatch(txtCidadeFornecedor.Text, @"[^0-9]+$"))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Cidade inválido!";
                }
                /* UF */
                else if (DpUF.SelectedValue.ToString() == "Selecionar...")
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo UF vazio!";
                }
                /* E-mail */
                else if (txtEmailFornecedor.Text == string.Empty)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo E-mail vazio!";
                }
                else
                {
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Fornecedor cadastrado com sucesso!";

                    FORNECEDOR cad_fornecedor = new FORNECEDOR();

                    cad_fornecedor.NOME = txtNomeFornecedor.Text;
                    cad_fornecedor.TELEFONE = txtTelefoneFornecedor.Text;
                    cad_fornecedor.CIDADE = txtCidadeFornecedor.Text;
                    cad_fornecedor.UF = DpUF.SelectedValue.ToString();
                    cad_fornecedor.EMAIL = txtEmailFornecedor.Text;

                    con_bd.FORNECEDOR.Add(cad_fornecedor);
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

        protected void txtNomeFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTelefoneFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCidadeFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtEmailFornecedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}