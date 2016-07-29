using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Bizagi.BLL
{
    public class Util
    {
        public static XmlDocument doc = new XmlDocument();
        public static string filePATH = "";

        public static XmlDocument NewDocumentTest()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);
            XmlNode WFProcessNode = doc.CreateElement("WorkflowProcess");
            doc.AppendChild(WFProcessNode);

            XmlNode ActivitiesNode = doc.CreateElement("Activities");
            XmlNode ParticipantsNode = doc.CreateElement("Participants");
            XmlNode TransitionsNode = doc.CreateElement("Transitions");
            XmlNode ExtendedAttributesNode = doc.CreateElement("ExtendedAttributes");

            // Have to do it b/c It wasnt making element like <element></element> :)
            ActivitiesNode.InnerText = "";
            ParticipantsNode.InnerText = "";
            TransitionsNode.InnerText = "";
            ExtendedAttributesNode.InnerText = "";

            // Template for the Workflow document.!
            WFProcessNode.AppendChild(ParticipantsNode);
            WFProcessNode.AppendChild(ActivitiesNode);
            WFProcessNode.AppendChild(TransitionsNode);
            WFProcessNode.AppendChild(ExtendedAttributesNode);
            // Template ends here

            return doc;
        }

        public static XmlDocument LoadXMLDocument(string path)
        {
            doc.Load(path);

            return doc;
        }

        public static bool LoadDocument(string PATH) {

        try
        {
            if (filePATH == "")
                filePATH = PATH;

            doc.Load(PATH);

        }
        catch (Exception ex)
        {
            if (ex.Message.ToString().Contains("Could not find"))
            {
                XmlDocument doc = new XmlDocument();
                XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                doc.AppendChild(docNode);
                XmlNode WFProcessNode = doc.CreateElement("WorkflowProcess");
                doc.AppendChild(WFProcessNode);

                XmlNode ActivitiesNode = doc.CreateElement("Activities");
                XmlNode ParticipantsNode = doc.CreateElement("Participants");
                XmlNode TransitionsNode = doc.CreateElement("Transitions");
                XmlNode ExtendedAttributesNode = doc.CreateElement("ExtendedAttributes");

                // Have to do it b/c It wasnt making element like <element></element> :)
                ActivitiesNode.InnerText = "";
                ParticipantsNode.InnerText = "";
                TransitionsNode.InnerText = "";
                ExtendedAttributesNode.InnerText = "";

                // Template for the Workflow document.!
                WFProcessNode.AppendChild(ParticipantsNode);
                WFProcessNode.AppendChild(ActivitiesNode);
                WFProcessNode.AppendChild(TransitionsNode);
                WFProcessNode.AppendChild(ExtendedAttributesNode);
                // Template ends here

                doc.Save(PATH);
                filePATH = PATH;
                LoadDocument(PATH);
            }

        }

        return true;
        }

        public static XmlElement CreateElement(string variable)
        {
            XmlElement empnode = doc.CreateElement(variable);
            return empnode;
        }

        public static XmlNode CreateNode(string variable, string value)
        {
            XmlNode tempnode = doc.CreateNode(System.Xml.XmlNodeType.Element,variable,"");
            tempnode.InnerText = value;
            return tempnode;
        }

        public static XmlNode CreateNode(string variable)
        {
            XmlNode tempnode = doc.CreateElement(variable);
            return tempnode;
        }

        public static void AddAttribute(XmlNode Node, string attributename, string attributeValue)
        {
            XmlAttribute Attribute = doc.CreateAttribute(attributename);
            Attribute.Value = attributeValue;
            Node.Attributes.Append(Attribute);
        }
    }
}

     