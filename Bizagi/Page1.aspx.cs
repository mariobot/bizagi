using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bizagi
{
    public partial class Page1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadFile_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads\\";

            if (fileUploadControl.HasFile)
                try
                {
                    fileUploadControl.SaveAs( path + fileUploadControl.FileName );

                    lblInfo.Text = "Nombre Archivo: " +
                         fileUploadControl.PostedFile.FileName + "<br>" +
                         "Tamaño: " + fileUploadControl.PostedFile.ContentLength + " kb<br>" +
                         "Tipo de contenido: " +
                         fileUploadControl.PostedFile.ContentType;
                }
                catch (Exception ex)
                {
                    lblInfo.Text = "ERROR: " + ex.Message.ToString();
                }
            else
                lblInfo.Text = "Usted no ha seleccionado un archivo" ;
        }
    }
}