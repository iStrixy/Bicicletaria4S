using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;

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

            lblError.Text = String.Empty;

        }
        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }
        private void limpar_campos()
        {
            tb_nome.Text = String.Empty;
            tb_rua.Text = String.Empty;
            tb_number.Text = String.Empty;
            tb_bairro.Text = String.Empty;
            tb_cmpt.Text = String.Empty;
            tb_cep.Text = String.Empty;
            tb_cpf.Text = String.Empty;
            tb_email.Text = String.Empty;
            tb_tel.Text = String.Empty;
        }
        protected void bt_cadastrar_Click(object sender, EventArgs e)
        {
            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
            {
                lblError.Text = string.Empty;
                int number = 0;
                int cep = 0;
                double tel, cpf1;
                string cep_max = tb_cep.Text;
                string tel_max = tb_tel.Text;
                string cpf_max = tb_cpf.Text;
                string nome = tb_nome.Text;

                if (!int.TryParse(tb_number.Text, out number))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Número inválido";
                }
                else if (!Regex.IsMatch(tb_nome.Text, @"[^0-9]+$"))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Nome inválido!";
                }
                else if (!int.TryParse(tb_cep.Text, out cep))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CEP inválido";
                }
                else if (cep_max.Length < 8)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CEP inválido";
                }
                else if (cep_max.Length > 8)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CEP inválido";
                }
                else if (!double.TryParse(tb_tel.Text, out tel))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone inválido!";
                }
                else if (tel_max.Length > 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone inválido";
                }
                else if (tel_max.Length < 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo Telefone inválido";
                }
                else if (!double.TryParse(tb_cpf.Text, out cpf1))
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CPF inválido";
                }
                else if (cpf_max.Length > 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CPF inválido";
                }
                else if (cpf_max.Length < 11)
                {
                    lblError.ForeColor = System.Drawing.Color.Red;
                    lblError.Text = "Campo CPF inválido";
                }
                else
                {
                    string cpf = tb_cpf.Text;
                    string email = tb_email.Text;
                    PESSOA cliente = con_bd.PESSOA.Where(linha => linha.CPF.Equals(cpf)).FirstOrDefault();
                    PESSOA clientemail = con_bd.PESSOA.Where(linha => linha.EMAIL.Equals(email)).FirstOrDefault();
                    if (cliente != null)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "CPF já cadastrado!";
                    }
                    else if (clientemail != null)
                    {
                        lblError.ForeColor = System.Drawing.Color.Red;
                        lblError.Text = "E-mail já cadastrado!";
                    }
                    else
                    {
                        lblError.ForeColor = System.Drawing.Color.Green;
                        lblError.Text = "Usuário cadastrado com sucesso!";

                        PESSOA cad_pessoa = new PESSOA();

                        cad_pessoa.NOME = tb_nome.Text;
                        cad_pessoa.LOGRADOURO = tb_rua.Text;
                        cad_pessoa.NUM_LOGRADOURO = Convert.ToInt32(tb_number.Text);
                        cad_pessoa.BAIRRO = tb_bairro.Text;
                        cad_pessoa.COMPLEMENTO = tb_cmpt.Text;
                        cad_pessoa.CEP = Convert.ToInt32(tb_cep.Text);
                        cad_pessoa.CPF = tb_cpf.Text;
                        cad_pessoa.EMAIL = tb_email.Text;
                        cad_pessoa.TELEFONE = tb_tel.Text;

                        con_bd.PESSOA.Add(cad_pessoa);
                        con_bd.SaveChanges();
                        limpar_campos();
                    }
                }
            }
        }

        protected void tb_cpf_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tb_email_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tb_nome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}