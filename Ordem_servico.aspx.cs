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
            //List<ORCAMENTO> orcamento = con_bd.ORCAMENTO.Where(linha => linha.);
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

            string nomeArquivo = @"D:\Orçamento.pdf";
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            doc.Open();
            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));

            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("ORÇAMENTO\n");
            paragrafo.Add("\n");

            using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
            {
                int ID = Convert.ToInt32(gvOrdemServico.SelectedValue.ToString());
                ORCAMENTO orc = con_bd.ORCAMENTO.Where(linha => linha.ID == ID).FirstOrDefault();

                lblNome.Text = orc.PESSOA.NOME.ToString();
                lblFunc.Text = orc.LOGIN.NOME_FUNCIONARIO.ToString();
                lblValor.Text = orc.VALOR_TOTAL.ToString("C");
                lblIDc.Text = gvOrdemServico.SelectedValue.ToString();

                //List<REG_SERV_ORCAMENTO> listserv = new List<REG_SERV_ORCAMENTO>();
                //{
                //    REG_SERV_ORCAMENTO reg_sv_null = null;
                //    int IDS = Convert.ToInt32(lblIDc.Text);
                //    reg_sv_null = con_bd.REG_SERV_ORCAMENTO.Where(linha1 => linha1.ID_ORCAMENTO.Equals(IDS)).FirstOrDefault();

                    //lblServico.Text = lblIDc.Text;

                    //SERVICO sv_null = null;
                    //int IDSS = Convert.ToInt32(lblServico.Text);
                    //SERVICO sv_null1 = con_bd.SERVICO.Where(linha3 => linha3.ID.Equals(IDSS)).FirstOrDefault();

                    //sv_null.DESCRICAO = lblServico.Text;
                    //lblServico.Text = sv_null1.DESCRICAO;

                //    lblServico.Text = reg_sv_null.ID_SERVICO.ToString();

                //    listserv.Add(reg_sv_null);

                //    for (int i = 0; i < listserv.Count; i++)
                //    {
                //        lblServico.Text = reg_sv_null.ID_SERVICO.ToString();
                //    }
                //}

                
                int IDP = Convert.ToInt32(lblIDc.Text);
                var prods = con_bd.PROD_ORCAMENTO.Where(linha2 => linha2.ID_ORCAMENTO.Equals(IDP)).ToList();
                string items_string = string.Empty;

                foreach(PROD_ORCAMENTO po in prods)
                {
                    items_string += po.PRODUTO.DESCRICAO + ";" + "\n";
                }

                //List<PROD_ORCAMENTO> listprod = new List<PROD_ORCAMENTO>();
                //{
                //PROD_ORCAMENTO prod_orc_null = null;
                //int IDP = Convert.ToInt32(lblIDc.Text);
                //prod_orc_null = con_bd.PROD_ORCAMENTO.Where(linha2 => linha2.ID_ORCAMENTO.Equals(IDP)).FirstOrDefault();

                //lblProduto.Text = prod_orc_null.ID_PRODUTO.ToString();

                //listprod.Add(prod_orc_null);

                //for (int i = 0; i < listprod.Count; i++)
                //{
                //lblProduto.Text = prod_orc_null.ID_PRODUTO.ToString();
                //}

                //}

                paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
                paragrafo.Alignment = Element.ALIGN_LEFT;
                paragrafo.Add("Nº do orçamento: " + lblIDc.Text + "\n");
                paragrafo.Add("Cliente: " + lblNome.Text + "\n");
                paragrafo.Add("Funcionário: " + lblFunc.Text + "\n");
                paragrafo.Add("\n");
                paragrafo.Add("Pedidos\n");
                paragrafo.Add("\n");
                paragrafo.Add("Produto(s) nº: " + items_string + "\n");
                //paragrafo.Add("Serviço(s) nº: " + lblServico.Text + "\n");
                paragrafo.Add("VALOR: " + lblValor.Text + "\n");
                paragrafo.Add("\n");
                paragrafo.Add("Assinatura do funcionário\n");
                paragrafo.Add("_________________________\n");
                paragrafo.Add("Assinatura do cliente\n");
                paragrafo.Add("_________________________\n");
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
                    string ID = gvOrdemServico.SelectedValue.ToString();
                    lblIDc.Text = gvOrdemServico.SelectedValue.ToString();
                    ORCAMENTO orcamento = con_bd.ORCAMENTO.Where(linha5 => linha5.ID.ToString().Equals(ID)).FirstOrDefault();
                    REG_SERV_ORCAMENTO servico = con_bd.REG_SERV_ORCAMENTO.Where(linha8 => linha8.ID_ORCAMENTO.ToString().Equals(lblIDc.Text)).FirstOrDefault();
                    PROD_ORCAMENTO produto = con_bd.PROD_ORCAMENTO.Where(linha9 => linha9.ID_ORCAMENTO.ToString().Equals(lblIDc.Text)).FirstOrDefault();
                    con_bd.REG_SERV_ORCAMENTO.Remove(servico);
                    con_bd.PROD_ORCAMENTO.Remove(produto);
                    con_bd.ORCAMENTO.Remove(orcamento);

                    //REG_SERV_ORCAMENTO reg_sv_null;
                    //int IDS = Convert.ToInt32(lblIDc.Text);
                    //reg_sv_null = con_bd.REG_SERV_ORCAMENTO.Where(linha6 => linha6.ID_ORCAMENTO.Equals(IDS)).FirstOrDefault();
                    //con_bd.REG_SERV_ORCAMENTO.Remove(reg_sv_null);

                    //PROD_ORCAMENTO reg_pd_null;
                    //int IDP = Convert.ToInt32(lblIDc.Text);
                    //reg_pd_null = con_bd.PROD_ORCAMENTO.Where(linha7 => linha7.ID_ORCAMENTO.Equals(IDP)).FirstOrDefault();
                    //con_bd.PROD_ORCAMENTO.Remove(reg_pd_null);

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Orçamento excluído com sucesso!";
                }
            }
        }

        protected void btnConcluido_Click(object sender, EventArgs e)
        {

        }
    }
}