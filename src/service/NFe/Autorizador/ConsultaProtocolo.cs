using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using NFe.Leiaute;

namespace NFe.Autorizador
{
    public class ConsultaProtocolo
    {
        public static XmlNode ExecutarNFCe(consSitNFe consSitNFe, string url, X509Certificate2 certificado)
        {
            // Xml - Pedido - Dados
            XmlNode xmlNodePedido = consSitNFe.CarregaXML();

            #region Request / Response

            //Request
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.ContentType = "application/soap+xml; charset=utf-8; action=\"http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4/nfeConsultaNF\"";
            webRequest.Accept = "gzip,deflate";
            webRequest.Method = "POST";

            //Certificates
            webRequest.ClientCertificates.Add(certificado);

            //Others
            webRequest.Timeout = 60000;
            webRequest.CookieContainer = new CookieContainer();
            webRequest.UserAgent = Guid.NewGuid().ToString();
            webRequest.ConnectionGroupName = webRequest.UserAgent;

            //soap:Envelope
            XmlDocument soapRequestXml = new XmlDocument();
            soapRequestXml.LoadXml(string.Format(@"<?xml version=""1.0"" encoding=""utf-8""?>
            <soap:Envelope xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
               <soap:Header/>
               <soap:Body>
                  <nfeDadosMsg xmlns=""http://www.portalfiscal.inf.br/nfe/wsdl/NFeConsultaProtocolo4"">{0}</nfeDadosMsg>
               </soap:Body>
            </soap:Envelope>", xmlNodePedido.OuterXml));

            using (Stream stream = webRequest.GetRequestStream())
            {
                soapRequestXml.Save(stream);
            }

            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    string soapResult = rd.ReadToEnd();

                    try
                    {
                        //Carrega resposta
                        XmlDocument soapResponseXml = new XmlDocument();
                        soapResponseXml.LoadXml(soapResult);

                        //Recupera elemento "nfeResultMsg"
                        XmlNode xmlNodeResult = soapResponseXml.GetElementsByTagName("nfeResultMsg")[0] as XmlNode;
                        if (xmlNodeResult == null)
                            throw new Exception("Tag 'nfeResultMsg' não encontrada");

                        // Xml - Retorno - Tratar
                        XmlNode xmlNodeRetorno = xmlNodeResult.FirstChild;
                        xmlNodeRetorno.Prefix = null; //Remove prefixo
                        xmlNodeRetorno.Attributes.RemoveAt(0); //Remove atributo (xmlns:retConsSitNFe="http://www.portalfiscal.inf.br/nfe")

                        // Retorna
                        return xmlNodeRetorno;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Concat("Erro na resposta do webservice: ", ex.Message));
                    }
                }
            }

            //Retorna
            return null;

            #endregion Request / Response
        }
    }
}
