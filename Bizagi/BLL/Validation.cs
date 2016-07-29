using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Bizagi.BLL
{
    public class Validation
    {
        public static XmlDocument doc = new XmlDocument();

        public static string Style0104(string fileSelected)
        {
            List<string> NameNodes = new List<string>();
            string response = "";

            doc.Load(fileSelected);
            XmlNodeList listNodes = doc.GetElementsByTagName("Activity");

            for (int i = 0; i < listNodes.Count; i++)
                NameNodes.Add(listNodes[i].Attributes["Name"].Value);

            var duplicatesNameNodes = NameNodes.GroupBy(s => s).SelectMany(gp => gp.Skip(1));

            if (duplicatesNameNodes.Count() != 0)
            {
                foreach (string item in duplicatesNameNodes.ToList<string>() )
	            {
                    response += "ERROR STYLE 0104 - Dos actividades no pueden tener el mismo nombre." + Environment.NewLine +
                             "Etiqueta repetida con el nombre : " + item + Environment.NewLine;
	            }
            }
            
            return response;
        }

        public static string Style0115(string fileSelected)
        {
            string response = "";

            doc.Load(fileSelected);
            XmlNodeList listNodes = doc.GetElementsByTagName("Activity");

            for (int i = 0; i < listNodes.Count; i++)
            {
                if (listNodes[i].Attributes["Name"].Value == string.Empty)
                {
                    response += "ERROR STYLE 0115 - Las etiquetas deben estar etiquetadas. " + Environment.NewLine +
                                "id: " + listNodes[i].Attributes["Id"].Value + Environment.NewLine;
                }
            }

            return response;
        }

        public static string Bpmn0102(string fileSelected)
        {
            string response = "";
            List<string> NodesAct = new List<string>();
            List<string> NodesTranFrom = new List<string>();
            List<string> NodesTranTo = new List<string>();

            doc.Load(fileSelected);

            XmlNodeList listNodesActivities = doc.GetElementsByTagName("Activity");
            XmlNodeList listNodeTransitions = doc.GetElementsByTagName("Transition");

            for (int i = 0; i < listNodesActivities.Count; i++)
                NodesAct.Add(listNodesActivities[i].Attributes["Id"].Value);

            for (int i = 0; i < listNodeTransitions.Count; i++) { 
                NodesTranFrom.Add(listNodeTransitions[i].Attributes["From"].Value);
                NodesTranTo.Add(listNodeTransitions[i].Attributes["To"].Value);
            }

            foreach (string Activity in NodesAct)
            {
                bool flag = false;

                foreach (string Transition in NodesTranFrom)
                    if (Transition == Activity)
                        flag = true;

                foreach (string Transition in NodesTranTo)
                    if (Transition == Activity)
                        flag = true;

                if (!flag)
                    response += "ERROR Bpmn0102: No esta relacionado a una transicion " + Environment.NewLine +
                                "Id: " + Activity + Environment.NewLine;
            }

            return response;
        }
    }
}