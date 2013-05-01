using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParser
{
    /// <summary>
    /// Clase que se utiliza para parsear el xml ejercicio1 
    /// </summary>
    class Builder
    {
        /// <summary>
        /// Utiliza la clase XmLDocument para parsear el xml en lugar de XmlReader como utilizaba el profesor, esta utiliza XPath como XSLT
        /// </summary>
        /// <param name="src">localización del fichero</param>
        public void build(String src)
        {
            Console.WriteLine("Bienvenido al XMLParser, este proyecto generara un HTML tomando como fuente el fichero XML del ejercicio 1");
            XmlDocument doc = new XmlDocument();
            doc.Load(src);
            String res = "<!DOCTYPE html>\n<html lang='es'>\n<head>\n<title>Parser XML Java</title>\n<meta charset = 'utf-8'>\n<link rel='stylesheet' type='text/css' href='estilo.css'>\n</head>\n<body>\n<header>\n<h1>";

            XmlNode root = doc.SelectSingleNode("parking");
            
            res += root.Attributes[0].InnerText + "</h1>\n</header>\n";
            res += "<section>\n";
            XmlNodeList plazas = doc.SelectNodes("parking/plaza");
            foreach (XmlNode plaza in plazas)
            {
                res += "<h2> Plaza: " + plaza.Attributes[0].InnerText + "-"
					+ plaza.Attributes[1].InnerText + "-"
					+ plaza.Attributes[2].InnerText + "</h2>\n";

                XmlNode inter = plaza.ChildNodes[0];
                
			    res += "<article>\n" + "<p>" + inter.Attributes[0].InnerText + " " + inter.Attributes[1].InnerText + " tiene " + inter.ChildNodes.Count + " coche/s en el parking."	+ "</p>\n</article>\n";
            }


            res += "</section>\n</body>\n</html>";
		    serialize(res);

            Console.WriteLine("HTML generado.");
        
        }

        /// <summary>
        /// Serializa el fichero en disco resultante de parsear el xml en html
        /// </summary>
        /// <param name="res">html generado</param>
        private void serialize(String res)
        {

            System.IO.StreamWriter sw = new System.IO.StreamWriter("../../out/index.html", false);
            sw.WriteLine(res);
            sw.Close();

        }

    }
}
