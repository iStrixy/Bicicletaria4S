using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class TeladeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_entrar_Click(object sender, EventArgs e)
        {
            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
            {
                if (tb_user.Text == string.Empty)
                {
                    lb_error.Text = "Preencha o campo usuário";
                }
                else if (tb_pw.Text == string.Empty)
                {
                    lb_error.Text = "Preencha o campo senha";
                }
                else
                {
                    string usuario = tb_user.Text;
                    string senha = tb_pw.Text;

                    LOGIN userlogado = con_bd.LOGIN.Where(linha => linha.LOGIN1.Equals(usuario) && linha.SENHA.Equals(senha)).FirstOrDefault();

                    if (userlogado != null)
                    {
                        Session["userlogado"] = userlogado.NOME_FUNCIONARIO;
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        lb_error.Text = "Usuário não encontrado";
                    }
                }
            }
        }

        protected void tb_user_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tb_pw_TextChanged(object sender, EventArgs e)
        {

        }
    }
}