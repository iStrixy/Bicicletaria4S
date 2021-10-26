using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PROJ_INTER_BC4S
{
    public partial class Consulta_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
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
            else if (gvCliente.SelectedValue != null)
            {
                btnEditar.Enabled = true;
            }
                lblError.Text = String.Empty;
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
            int cpf = 0;
            int tel = 0;
            txtTelCliente.MaxLength = 11;
            txtCepCliente.MaxLength = 8;
            txtCpfCliente.MaxLength = 11;
            if (!int.TryParse(txtNumeroCliente.Text, out number))
            {
                lblError.Text = "Campo Número inválido";
            }
            else if(!int.TryParse(txtCepCliente.Text, out cep) || txtCepCliente.MaxLength > 8)
            {
                lblError.Text = "Campo CEP inválido";
            }
            else if(!int.TryParse(txtCpfCliente.Text, out cpf) || txtCpfCliente.MaxLength > 11)
            {
                lblError.Text = "Campo CPF inválido";
            }
            else if(!int.TryParse(txtTelCliente.Text, out tel) || txtTelCliente.MaxLength > 11)
            {
                lblError.Text = "Campo Telefone inválido";
            }
            else
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PESSOA pessoa = null;
                    if(lblError.Text.Equals(String.Empty))
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
                    pessoa.TELEFONE = Convert.ToInt32(txtTelCliente.Text);

                    if(lblError.Text.Equals(String.Empty))
                    {
                        con_bd.Entry(pessoa);
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
            if(gvCliente.SelectedValue != null)
            {
                btnExcluir.Enabled = true;
                btnSalvar.Enabled = true;
                lblError.Text = String.Empty;
                int ID = Convert.ToInt32(gvCliente.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    PESSOA pessoa = con_bd.PESSOA.Where(linha => linha.ID == ID).FirstOrDefault();
                    if(pessoa != null)
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
                    }
                }
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if(gvCliente.SelectedValue != null)
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