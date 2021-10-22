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

        }

        protected void bt_cadastrar_Click(object sender, EventArgs e)
        {
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
