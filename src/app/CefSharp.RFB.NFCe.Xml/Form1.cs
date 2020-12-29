using CefSharp;
using CefSharp.WinForms;
using NFe.Auxiliar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml;

namespace CefSharp.RFB.NFCe.Xml
{
    public partial class Form1 : Form
    {
        private string url = string.Empty;
        private string xUF = string.Empty;
        private string chave = string.Empty;
        private System.Xml.XmlDocument notaFiscal = null;

        #region Controles

        private ChromiumWebBrowser chromeBrowser = null;

        #endregion Controles

        #region Construtor

        public Form1()
        {
            InitializeComponent();

            // Set icon
            this.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        #endregion Construtor

        #region Eventos - Formulário

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            chromeBrowser.Dispose();
        }

        #endregion Eventos - Formulário

        #region Eventos - Browser

        private void ChromeBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                chromeBrowser.GetSourceAsync().ContinueWith(taskHtml =>
                {
                    var html = taskHtml.Result;

                    if(xUF == "MG")
                    {
                        if (html.Contains("formPrincipal:chaveacesso"))
                        {
                            txtNFCeChave.Invoke((Action)delegate
                            {
                                chromeBrowser.ExecuteScriptAsync(string.Format("document.getElementById('formPrincipal:chaveacesso').value = \"{0}\";", txtNFCeChave.Text));
                            });
                        }

                        if (html.Contains("formPrincipal:content-template-consulta"))
                        {
                            // Load From String
                            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                            htmlDocument.LoadHtml(html);

                            if (html.Contains("formPrincipal:j_idt108:j_idt109"))
                            {
                                var div = htmlDocument.GetElementbyId("formPrincipal:j_idt108:j_idt109").SelectNodes("div");
                                var table = div[1].SelectNodes("table");
                                var td = table[1].SelectNodes("tbody//tr//td");
                                string digestValue = td[2].InnerText;

                                txtNFCeDigestValue.Invoke((Action)delegate
                                {
                                    txtNFCeDigestValue.Text = digestValue;
                                });
                            }
                        }
                    }
                });
            }
        }

        #endregion Eventos - Browser

        private void btnNFCePesquisarAutorizador_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtNFCeChave.Text))
                    throw new ApplicationException("Informe a Chave de Acesso");

                btnNFCeMontarXml.Enabled = false;

                //UF do Emitente
                string cUF = txtNFCeChave.Text.Substring(0, 2);
                xUF = IBGE.RetornaSiglaUF(cUF);
                chave = txtNFCeChave.Text;

                url = Provedores.RetornaUrlConsultaChave(xUF);

                chromeBrowser = new ChromiumWebBrowser(url);
                chromeBrowser.FrameLoadEnd += ChromeBrowser_FrameLoadEnd;
                chromeBrowser.RequestHandler = new WinFormsRequestHandler();

                pnlAutorizador.Controls.Clear();
                // Add it to the form and fill it to the form window.
                pnlAutorizador.Controls.Add(chromeBrowser);
                chromeBrowser.Dock = DockStyle.Fill;
            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message,"Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNFCeSelecionarPastaPedidos_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog frmFolderBrowserDialog = new FolderBrowserDialog())
            {
                if (frmFolderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //Atualiza caixa de texto
                    txtNFCePastaPedidos.Text = frmFolderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnPesquisarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtNFCeChave.Text))
                    throw new ApplicationException("Informe a pasta de pedidos da NFC-e");

                string[] arquivos = Directory.GetFiles(txtNFCePastaPedidos.Text);

                Cursor.Current = Cursors.WaitCursor;
                gbxInformacoesNFCe.Enabled = false;

                foreach (var item in arquivos)
                {
                    if (!item.Contains(".xml"))
                        continue;

                    System.Xml.XmlDocument xml = new System.Xml.XmlDocument();
                    xml.Load(item);

                    XmlNode xmlEnviNFe = xml.GetElementsByTagName("enviNFe")[0];
                    if (xmlEnviNFe != null)
                    { 
                        XmlNode xmlChNFe = xml.GetElementsByTagName("infNFe")[0].Attributes.GetNamedItem("Id");
                        XmlNode xmlNFe = xml.GetElementsByTagName("NFe")[0];
                        XmlNode xmlDigestValue  = xml.GetElementsByTagName("DigestValue")[0];

                        if(txtNFCeChave.Text == xmlChNFe.InnerText.Substring(3,44))
                        {
                            if(txtNFCeDigestValue.Text == xmlDigestValue.InnerText)
                            {

                                notaFiscal = new System.Xml.XmlDocument();
                                notaFiscal.LoadXml(xmlNFe.OuterXml);

                                btnNFCeMontarXml.Enabled = true;
                                break;
                            }
                        }
                    }
                }

            }
            catch (ApplicationException ae)
            {
                MessageBox.Show(ae.Message,"Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                gbxInformacoesNFCe.Enabled = true;
            }
        }

        private void btnNFCeMontarXml_Click(object sender, EventArgs e)
        {
            //UF do Emitente
            string cUF = txtNFCeChave.Text.Substring(0, 2);

            //Monta consulta da situação da NF-e
            NFe.Leiaute.consSitNFe consSitNFe = new NFe.Leiaute.consSitNFe();
            consSitNFe.tpAmb = 1;
            consSitNFe.chNFe = txtNFCeChave.Text;
            consSitNFe.cUF = Convert.ToInt32(cUF);

            //Ceritificado
            X509Certificate2 certificado = null;
            certificado = NFe.Auxiliar.Certificado.RecuperarPorNome("");

            //Envia consulta da situação da NF-e
            XmlElement xmlRetConsSitNFe = NFe.Autorizador.ConsultaProtocolo.ExecutarNFCe(consSitNFe, @"https://nfe.sefaz.go.gov.br/nfe/services/NFeConsultaProtocolo4",certificado) as XmlElement;

            //Retorno 
            if (xmlRetConsSitNFe == null)
                throw new Exception("Webservice não retornou uma resposta para a solicitação enviada.");

            //Veririfca se documento de protNFe foi informado
            XmlNode xmlNode_protNFe = xmlRetConsSitNFe.GetElementsByTagName("protNFe")[0];

            string diretorio = string.Empty;

            //Formulário para seleção da pasta
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                //Aborta
                if (folderBrowserDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                diretorio = folderBrowserDialog.SelectedPath;
            }

            XmlElement xmlNode_NFe = notaFiscal.GetElementsByTagName("NFe")[0] as XmlElement;

            //Cria documento
            System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
            xmlDocument.PreserveWhitespace = true;

            //Cria elemento raiz
            XmlNode xmlNode_nfeProc = xmlDocument.CreateElement("nfeProc");

            //Adiciona o atributo namespace(xmlns) no elemento raiz
            XmlAttribute attributeXmlns = xmlDocument.CreateAttribute("xmlns");
            attributeXmlns.InnerText = "http://www.portalfiscal.inf.br/nfe";
            xmlNode_nfeProc.Attributes.Append(attributeXmlns);

            //Adiciona atributo versão no elemento raiz
            XmlAttribute attributeVersao = xmlDocument.CreateAttribute("versao");
            attributeVersao.InnerText = "4.00";
            xmlNode_nfeProc.Attributes.Append(attributeVersao);

            //Adiciona documento NFe
            xmlNode_nfeProc.AppendChild(xmlDocument.ImportNode(xmlNode_NFe, true));

            //Adiciona documento protNFe
            xmlNode_nfeProc.AppendChild(xmlDocument.ImportNode(xmlNode_protNFe, true));

            //Carrega documento
            xmlDocument.LoadXml(xmlNode_nfeProc.OuterXml);

            //Cria declaração
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);

            //Adiciona declaração
            xmlDocument.InsertBefore(xmlDeclaration, xmlDocument.DocumentElement);

            //Salva arquivo
            xmlDocument.Save(string.Format(@"{0}\\{1}-procNFe.xml",diretorio, txtNFCeChave.Text));
        }
    }
}
