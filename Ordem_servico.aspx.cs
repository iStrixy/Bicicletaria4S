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
            List<ORCAMENTO> orcamento = con_bd.ORCAMENTO.Where(linha => linha.STATUS.Equals("Em andamento...") || linha.STATUS.Equals("Concluído")).ToList();
            //List<ORCAMENTO> orcamento = con_bd.ORCAMENTO.ToList();
            gvOrdemServico.DataSource = orcamento;
            gvOrdemServico.DataBind();
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
            if (gvOrdemServico.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um orçamento para a impressão!";
            }
            else if (gvOrdemServico.SelectedValue != null)
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
                    lblData.Text = orc.DATA_ORC.ToString();

                    int IDP = Convert.ToInt32(lblIDc.Text);
                    var prods = con_bd.PROD_ORCAMENTO.Where(linha2 => linha2.ID_ORCAMENTO.Equals(IDP)).ToList();
                    string items_string = string.Empty;
                    string sub_pd = string.Empty;

                    foreach (PROD_ORCAMENTO po in prods)
                    {
                        items_string += po.PRODUTO.DESCRICAO + "(Quantidade: " + po.QUANTIDADE + ")" + "\n";
                    }

                    PROD_ORCAMENTO prod_orc_null = null;
                    int IDPSUB = Convert.ToInt32(lblIDc.Text);
                    prod_orc_null = con_bd.PROD_ORCAMENTO.Where(linha => linha.ID_ORCAMENTO.Equals(IDP)).FirstOrDefault();
                    lblProduto.Text = prod_orc_null.SUB_TOTAL.ToString();

                    int IDS = Convert.ToInt32(lblIDc.Text);
                    var servs = con_bd.REG_SERV_ORCAMENTO.Where(linha3 => linha3.ID_ORCAMENTO.Equals(IDS)).ToList();
                    string items_serv = string.Empty;
                    string sub_serv = string.Empty;

                    foreach (REG_SERV_ORCAMENTO sv in servs)
                    {
                        items_serv += sv.SERVICO.DESCRICAO + ";" + "\n";
                    }

                    paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold);
                    paragrafo.Alignment = Element.ALIGN_LEFT;
                    paragrafo.Add("Nº do orçamento: " + lblIDc.Text + "\n");
                    paragrafo.Add("Cliente: " + lblNome.Text + "\n");
                    paragrafo.Add("Funcionário: " + lblFunc.Text + "\n");
                    paragrafo.Add("\n");
                    paragrafo.Add("PEDIDOS\n");
                    paragrafo.Add("\n");
                    paragrafo.Add("Produto(s):\n" + items_string + "\n");
                    paragrafo.Add("Serviço(s):\n" + items_serv + "\n");
                    paragrafo.Add("\nVALOR: " + lblValor.Text + "\n");
                    paragrafo.Add("\n");
                    paragrafo.Add("Assinatura do funcionário\n");
                    paragrafo.Add("_________________________\n");
                    paragrafo.Add("Assinatura do cliente\n");
                    paragrafo.Add("_________________________\n");
                    paragrafo.Add("\n");
                    paragrafo.Add("Data: " + lblData.Text + "\n");
                }

                doc.Open();
                doc.Add(paragrafo);
                doc.Close();
                System.Diagnostics.Process.Start(@"D:\Orçamento.pdf");
                gvOrdemServico.SelectedIndex = -1;
            }
            gvOrdemServico.SelectedIndex = -1;
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (gvOrdemServico.SelectedValue == null)
            {
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "Selecione um dado!";
            }
            else if (gvOrdemServico.SelectedValue != null)
            {
                lblError.Text = string.Empty;
                int IDGV = Convert.ToInt32(gvOrdemServico.SelectedValue.ToString());
                using (BD_BICICLETARIA_4SEntities con_bd = new BD_BICICLETARIA_4SEntities())
                {
                    ORCAMENTO orcgv = con_bd.ORCAMENTO.Where(linha => linha.ID == IDGV).FirstOrDefault();
                    if(orcgv != null)
                    {
                        lblID.Text = orcgv.ID.ToString();
                    }

                    ORCAMENTO orcamento = null;
                    if (lblError.Text.Equals(string.Empty))
                    {
                        int ID = Convert.ToInt32(lblID.Text);
                        orcamento = con_bd.ORCAMENTO.Where(linha => linha.ID.Equals(ID)).FirstOrDefault();
                    }

                    orcamento.STATUS = Convert.ToString("Excluído");

                    if (lblError.Text.Equals(string.Empty))
                    {
                        con_bd.Entry(orcamento);
                    }

                    con_bd.SaveChanges();
                    carregarGrid(con_bd);
                    lblError.ForeColor = System.Drawing.Color.Green;
                    lblError.Text = "Orçamento excluído com sucesso!";
                    gvOrdemServico.SelectedIndex = -1;
                }
            }
        }
    }
}