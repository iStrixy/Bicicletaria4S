using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String nomeuserlogado = (String)Session["userlogado"];
            if (nomeuserlogado == null)
            {
                Response.Redirect("TeladeLogin.aspx");
            }
        }

        protected void bt_cadastrar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            int number = 0;
            int cep = 0;
            int cpf = 0;
            tb_tel.MaxLength = 10;
            if (!int.TryParse(tb_number.Text, out number))
            {
                lblError.Text = "Campo Número inválido";
            }
            else if (!int.TryParse(tb_cep.Text, out cep))
            {
                lblError.Text = "Campo CEP inválido";
            }
            else if (!int.TryParse(tb_cpf.Text, out cpf))
            {
                lblError.Text = "Campo CPF inválido!";
            }
            else if (!int.TryParse(tb_tel.Text, out cpf) || tb_tel.MaxLength > 10)
            {
                lblError.Text = "Campo inválido! ou utilize '1797480961' para cadastrar o número";
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Text = "Usuário cadastrado com sucesso!";
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PESSOA cad_pessoa = new PESSOA();
                    TELEFONE_PESSOA telefone = new TELEFONE_PESSOA();

                    cad_pessoa.NOME = tb_nome.Text;
                    cad_pessoa.LOGRADOURO = tb_rua.Text;
                    cad_pessoa.NUM_LOGRADOURO = Convert.ToInt32(tb_number.Text);
                    cad_pessoa.BAIRRO = tb_bairro.Text;
                    cad_pessoa.COMPLEMENTO = tb_cmpt.Text;
                    cad_pessoa.CEP = Convert.ToInt32(tb_cep.Text);
                    cad_pessoa.CPF = tb_cpf.Text;
                    cad_pessoa.EMAIL = tb_email.Text;
                    telefone.TELEFONE = Convert.ToInt32(tb_tel.Text);



                    con_bd.PESSOA.Add(cad_pessoa);
                    con_bd.SaveChanges();


                }

            }
        }
    }
}