using System.Xml;

namespace NFe.Auxiliar
{
    public class XmlDocument : System.Xml.XmlDocument
    {
        public void AddNode(XmlNode objNodeParent, string strNodeName, string strValue)
        {
            AddNode(objNodeParent, strNodeName, strValue, false);
        }

        public void AddNode(XmlNode objNodeParent, string strNodeName, string strValue, bool blnAllowEmpty)
        {
            if (blnAllowEmpty == false && strValue != null && strValue != string.Empty)
            {
                // Creates the node
                XmlNode objNode = CreateElement(strNodeName);

                // Sets the node value
                objNode.InnerText = strValue.Trim();

                // Append the node to it's parent
                objNodeParent.AppendChild(objNode);
            }
            else if (blnAllowEmpty == true)
            {
                // Creates the node
                XmlNode objNode = CreateElement(strNodeName);

                // Sets the node value
                if (strValue != null && strValue != string.Empty)
                    objNode.InnerText = strValue.Trim();

                // Append the node to it's parent
                objNodeParent.AppendChild(objNode);
            }
        }
    }
}
