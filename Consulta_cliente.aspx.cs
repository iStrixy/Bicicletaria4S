using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace PROJ_INTER_BC4S
{
    public partial class Consulta_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;
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

        private void limpar_campos()
        {
            txtNomeCliente.Text = String.Empty;
            txtRuaCliente.Text = String.Empty;
            txtNumeroCliente.Text = String.Empty;
            txtBairroCliente.Text = String.Empty;
            txtComplementoCliente.Text = String.Empty;
            txtCepCliente.Text = String.Empty;
            txtCpfCliente.Text = String.Empty;
            txtEmailCliente.Text = String.Empty;
            txtTelCliente.Text = String.Empty;
        }

        private void carregarGrid(BD_BICICLETARIA_4SEntities con_bd)
        {
            List<PESSOA> pessoa = con_bd.PESSOA.ToList();
            gvCliente.DataSource = pessoa;
            gvCliente.DataBind();
        }

        protected void gvCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            lblError.Text = String.Empty;
            int number = 0;
            int cep = 0;
            double tel, cpf;
            string cep_max = txtCepCliente.Text;
            string tel_max = txtTelCliente.Text;
            string cpf_max = txtCpfCliente.Text;
            string nome = txtNomeCliente.Text;

            /* GridView */
            if(gvCliente.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            /* Nome */
            if (txtNomeCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Nome vazio!";
            }
            else if (!Regex.IsMatch(txtNomeCliente.Text, @"[^0-9]+$"))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Nome inválido!";
            }
            /* Rua */
            else if (txtRuaCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Rua vazio!";
            }
            /* Número casa */
            else if (txtNumeroCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Número vazio!";
            }
            else if (!int.TryParse(txtNumeroCliente.Text, out number))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Número inválido!";
            }
            /* Bairro */
            else if (txtBairroCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Bairro vazio!";
            }
            /* Complemento */
            else if (txtComplementoCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Complemento vazio!";
            }
            /* CEP */
            else if (txtCepCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CEP vazio!";
            }
            else if (!int.TryParse(txtCepCliente.Text, out cep))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CEP inválido!";
            }
            else if (cep_max.Length < 8)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CEP inválido!";
            }
            else if (cep_max.Length > 8)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CEP inválido!";
            }
            /* CPF */
            else if (txtCpfCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CPF vazio!";
            }
            else if (!double.TryParse(txtCpfCliente.Text, out cpf))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CPF inválido!";
            }
            else if (cpf_max.Length > 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CPF inválido!";
            }
            else if (cpf_max.Length < 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo CPF inválido!";
            }
            /* E-mail */
            else if (txtEmailCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo E-mail vazio!";
            }
            else if (!Regex.IsMatch(txtEmailCliente.Text, @"\@"))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo E-mail inválido!";
            }
            /* Telefone */
            else if (txtTelCliente.Text == string.Empty)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone vazio!";
            }
            else if (!double.TryParse(txtTelCliente.Text, out tel))
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (tel_max.Length > 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else if (tel_max.Length < 11)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Campo Telefone inválido!";
            }
            else
            {
                lblError.Text = string.Empty;
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PESSOA pessoa = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        pessoa = con_bd.PESSOA.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    pessoa.NOME = txtNomeCliente.Text;
                    pessoa.LOGRADOURO = txtRuaCliente.Text;
                    pessoa.NUM_LOGRADOURO = Convert.ToInt32(txtNumeroCliente.Text);
                    pessoa.BAIRRO = txtBairroCliente.Text;
                    pessoa.COMPLEMENTO = txtComplementoCliente.Text;
                    pessoa.CEP = Convert.ToInt32(txtCepCliente.Text);
                    pessoa.CPF = txtCpfCliente.Text;
                    pessoa.EMAIL = txtEmailCliente.Text;
                    pessoa.TELEFONE = txtTelCliente.Text;

                    if (lblError.Text.Equals(string.Empty))
                    {
                        con_bd.Entry(pessoa);
                    }

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Dados do cliente alterado com sucesso!";
                    limpar_campos();
                    gvCliente.SelectedIndex = -1;
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (gvCliente.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvCliente.SelectedValue != null)
            {
                int ID = Convert.ToInt32(gvCliente.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PESSOA pessoa = con_bd.PESSOA.Where(linha => linha.ID == ID).FirstOrDefault();
                    if (pessoa != null)
                    {
                        txtNomeCliente.Text = pessoa.NOME;
                        txtRuaCliente.Text = pessoa.LOGRADOURO;
                        txtNumeroCliente.Text = pessoa.NUM_LOGRADOURO.ToString();
                        txtBairroCliente.Text = pessoa.BAIRRO;
                        txtComplementoCliente.Text = pessoa.COMPLEMENTO;
                        txtCepCliente.Text = pessoa.CEP.ToString();
                        txtCpfCliente.Text = pessoa.CPF;
                        txtEmailCliente.Text = pessoa.EMAIL;
                        txtTelCliente.Text = pessoa.TELEFONE.ToString();
                        lblID.Text = pessoa.ID.ToString();
                    }
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gvCliente.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvCliente.SelectedValue != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    string ID = gvCliente.SelectedValue.ToString();
                    PESSOA pessoaselecionada = con_bd.PESSOA.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                    con_bd.PESSOA.Remove(pessoaselecionada);
                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Usuário excluído com sucesso!";
                    limpar_campos();
                }
            }
        }
    }
}