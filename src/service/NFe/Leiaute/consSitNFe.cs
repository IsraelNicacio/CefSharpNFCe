
using System.Xml;

namespace NFe.Leiaute
{
    public class consSitNFe : Auxiliar.XmlDocument
    {
        #region Propriedades

        public decimal versao { get; set; }
        public int tpAmb { get; set; }
        public int cUF { get; set; }
        public string xServ { get; set; }
        public string chNFe { get; set; }

        #endregion Propriedades

        #region Construtor

        // Need a public default no-arg constructor for COM Interop.
        public consSitNFe()
        {
            this.versao = 4.00M;
            this.tpAmb = 0;
            this.cUF = 0;
            this.xServ = "CONSULTAR";
            this.chNFe = null;
        }

        public consSitNFe(int tpAmb, int cUF, string chNFe)
        {
            this.versao = 4.00M;
            this.tpAmb = tpAmb;
            this.cUF = cUF;
            this.xServ = "CONSULTAR";
            this.chNFe = chNFe;

            CarregaXML();
        }

        #endregion Construtor

        #region Métodos - XML
        public XmlNode CarregaXML()
        {
            Auxiliar.XmlDocument xmlDocument = new Auxiliar.XmlDocument();

            // Cria o elemento raiz
            XmlNode xmlRaiz = xmlDocument.CreateElement("consSitNFe");

            // Cria o atributo namespace(xmlns)
            XmlAttribute attributeXmlns = xmlDocument.CreateAttribute("xmlns");
            attributeXmlns.InnerText = "http://www.portalfiscal.inf.br/nfe";
            xmlRaiz.Attributes.Append(attributeXmlns);

            // Cria o atributo versao
            XmlAttribute attributeVersao = xmlDocument.CreateAttribute("versao");
            attributeVersao.InnerText = "4.00";
            xmlRaiz.Attributes.Append(attributeVersao);

            // Adiciona demais elementos 
            xmlDocument.AddNode(xmlRaiz, "tpAmb", this.tpAmb.ToString());
            xmlDocument.AddNode(xmlRaiz, "xServ", this.xServ);
            xmlDocument.AddNode(xmlRaiz, "chNFe", this.chNFe);

            //Retorna
            return xmlRaiz;
        }
        #endregion Métodos - XML


    }
}
