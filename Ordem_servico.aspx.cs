using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;



namespace PROJ_INTER_BC4S
{


    public partial class Ordem_servico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            List<ORCAMENTO> orcamento = con_bd.ORCAMENTO.ToList();
            gvOrdemServico.DataSource = orcamento;
            gvOrdemServico.DataBind();
            //List<PROD_ORCAMENTO> prod_orcamento = con_bd.PROD_ORCAMENTO.ToList();
            //gvOrdemServico.DataSource = prod_orcamento;
            //gvOrdemServico.DataBind();
            //List<REG_SERV_ORCAMENTO> serv_orcamento = con_bd.REG_SERV_ORCAMENTO.ToList();
            //gvOrdemServico.DataSource = serv_orcamento;
            //gvOrdemServico.DataBind();
        }

        protected void lb_sair_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("TeladeLogin.aspx");
        }

        protected void gvOrdemServico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {

            string nomeArquivo = @"D:\orcamento.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            doc.Open();
            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));

            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("ORÇAMENTOS\n");

            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
            {
                int ID = Convert.ToInt32(gvOrdemServico.SelectedValue.ToString());
                ORCAMENTO orc = con_bd.ORCAMENTO.Where(linha => linha.ID == ID).FirstOrDefault();

                lblNome.Text = orc.PESSOA.NOME.ToString();
                lblFunc.Text = orc.LOGIN.NOME_FUNCIONARIO.ToString();
                lblValor.Text = orc.VALOR_TOTAL.ToString("C");
                lblIDc.Text = gvOrdemServico.SelectedValue.ToString();


                paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
                paragrafo.Alignment = Element.ALIGN_LEFT;
                paragrafo.Add("ID ORÇAMENTO: " + lblIDc.Text + "\n");
                paragrafo.Add("NOME CLIENTE: " + lblNome.Text + "\n");
                paragrafo.Add("NOME FUNCIONÁRIO: " + lblFunc.Text + "\n");
                paragrafo.Add("VALOR: " + lblValor.Text + "\n");
            }
               

            //string texto = "teste mano ";
            //paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
            //paragrafo.Alignment = Element.ALIGN_CENTER;
            //paragrafo.Add(texto + "\n");

            doc.Open();
            doc.Add(paragrafo);
            doc.Close();


        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gvOrdemServico == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvOrdemServico != null)
            {
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    //string ID = gvOrdemServico.SelectedValue.ToString();
                    //ORCAMENTO orcamentoselecionado = con_bd.ORCAMENTO.Where(linha => linha.ID.ToString().Equals(ID)).FirstOrDefault();
                }
            }
        }

        protected void btnConcluido_Click(object sender, EventArgs e)
        {

        }
    }
}