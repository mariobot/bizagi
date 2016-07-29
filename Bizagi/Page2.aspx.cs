using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Bizagi.BLL;

namespace Bizagi
{
    public partial class Page2 : System.Web.UI.Page
    {
        string fileSelected;

        protected void Page_Load(object sender, EventArgs e)
        {   
            fileSelected = Request.QueryString["val"];
            if (fileSelected != null)
                LoadFile();
        }

        protected void btnVerificar_Click(object sender, EventArgs e)
        {
            try
            {
                CleartxtResult();
                txtResult.Text = Bizagi.BLL.Util.NewDocumentTest().InnerXml;
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            if (fileSelected != null )
            {
                lblFile.Text = "";
                txtConsole.Text = "";
                txtConsole.Text += Validation.Style0115(fileSelected);
                txtConsole.Text += Validation.Style0104(fileSelected);
                txtConsole.Text += Validation.Bpmn0102(fileSelected);
            }
            else
                lblFile.Text = "Seleccione un archivo en el panel Derecho --->  ";
        }

        private void LoadFile()
        {
            CleartxtResult();

            if (fileSelected != null)
            {
                try
                {
                    string xml = Util.LoadXMLDocument(fileSelected).InnerXml;
                    lblFile.Text = fileSelected;
                    txtResult.Text = xml;
                }
                catch (Exception ex) { lblInfo.Text = ex.Message; }
            }
        }

        private void ReadNodes() {
            if (fileSelected != null)
            {
                try
                {
                    XmlDocument xml = Util.LoadXMLDocument(fileSelected);

                    XmlTextReader xmlReader = new XmlTextReader(fileSelected);

                    XmlDocument doc = new XmlDocument();
                    XmlNode node = doc.ReadNode(xmlReader);

                    doc.Load(fileSelected);
                    XmlNodeList listNodes = doc.GetElementsByTagName("Activity");

                    for (int i = 0; i < listNodes.Count; i++)
                    {
                        txtConsole.Text += "Id : " +  listNodes[i].Attributes["Id"].Value + Environment.NewLine +
                        "Name: " + listNodes[i].Attributes["Name"].Value + Environment.NewLine;
                    }
                }
                catch (Exception ex) { lblInfo.Text = ex.Message; }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e){ CleartxtResult(); }

        private void CleartxtResult()
        {
            if (txtResult.Text != string.Empty){
                txtResult.Text = "";
                txtConsole.Text = "";
            }
        }
    }
}