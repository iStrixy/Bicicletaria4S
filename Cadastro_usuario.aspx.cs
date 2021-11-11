using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Cadastro_usuario : System.Web.UI.Page
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
            txtNomeUsuario.Text = string.Empty;
            txtLogin.Text = string.Empty;
            txtSenha.Text = string.Empty;
        }

        protected void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtNomeUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            /* Nome completo */
            if (txtNomeUsuario.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Nome vazio!";
            }
            else if (!Regex.IsMatch(txtNomeUsuario.Text, @"[^0-9]+$"))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Nome inválido!";
            }
            /* Usuário */
            else if (txtLogin.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Usuário vazio!";
            }
            /* Senha */
            else if (txtSenha.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Senha vazio!";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Usuário cadastrado com sucesso!";
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    LOGIN cad_login = new LOGIN();
                    cad_login.NOME_FUNCIONARIO = txtNomeUsuario.Text;
                    cad_login.LOGIN1 = txtLogin.Text;
                    cad_login.SENHA = txtSenha.Text;

                    con_bd.LOGIN.Add(cad_login);
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