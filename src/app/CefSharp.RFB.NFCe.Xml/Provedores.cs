using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CefSharp.RFB.NFCe.Xml
{
    public class Provedores
    {
        public static string RetornaUrlConsultaChave(string sigla)
        {
            //Variavel de retorno
            string strRetorno = string.Empty;

            //Arquivo
            string filename = Path.Combine(Application.StartupPath, "Resources\\Urls\\ConsultaNFCe.xml");
            FileInfo objFileInfo = new FileInfo(filename);
            if (objFileInfo.Exists)
            {
                using (FileStream objFileStream = objFileInfo.OpenRead())
                {
                    //Arquivo xml
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(objFileStream);
                    //Elelemto raíz
                    XmlNode xmlRoot = xmlDocument.SelectSingleNode("WS");
                    //Elemento UF
                    XmlNode xmlUF = xmlRoot.SelectSingleNode("UF[sigla='" + sigla + "']");

                    if (xmlUF == null)
                        throw new Exception("Não foi possível encontrar o Endereço Url para consulta da NFC-e com a sigla requisitada.");

                    //Elemento URL
                    XmlNode xmlUrl = null;

                    xmlUrl = xmlUF.SelectSingleNode("ConsultaWeb");

                    //Define retorno
                    if (xmlUrl != null)
                    {
                        strRetorno = xmlUrl.InnerText;
                    }
                }
            }
            else
            {
                throw new Exception("Arquivo com URL de consulta não encontrado.");
            }

            //Retornar
            return strRetorno;
        }

        public static string RetornarAutorizador(string sigla)
        {
            //Variavel de retorno
            string strRetorno = string.Empty;

            //Arquivo
            string filename = Path.Combine(Application.StartupPath, "Resources\\Urls\\v400.xml");
            FileInfo objFileInfo = new FileInfo(filename);
            if (objFileInfo.Exists)
            {
                using (FileStream objFileStream = objFileInfo.OpenRead())
                {
                    //Arquivo xml
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(objFileStream);
                    //Elelemto raíz
                    XmlNode xmlRoot = xmlDocument.SelectSingleNode("WS");
                    //Elemento UF
                    XmlNode xmlUF = xmlRoot.SelectSingleNode("UF[sigla='" + sigla + "']");

                    if (xmlUF == null)
                        throw new Exception("Não foi possível encontrar o Endereço Url para consulta da NFC-e com a sigla requisitada.");

                    //Elemento URL
                    XmlNode xmlUrl = null;

                    xmlUrl = xmlUF.SelectSingleNode("Consulta");

                    //Define retorno
                    if (xmlUrl != null)
                    {
                        strRetorno = xmlUrl.InnerText;
                    }
                }
            }
            else
            {
                throw new Exception("Arquivo com URL de consulta não encontrado.");
            }

            //Retornar
            return strRetorno;
        }
    }
}
