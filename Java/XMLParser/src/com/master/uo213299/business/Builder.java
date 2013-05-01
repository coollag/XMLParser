package com.master.uo213299.business;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

import org.jdom.Document;
import org.jdom.Element;
import org.jdom.JDOMException;
import org.jdom.input.SAXBuilder;

public class Builder {

	private String path;

	public Builder(String path) {
		this.path = path;
	}

	public void build() throws FileNotFoundException, JDOMException,
			IOException {

		SAXBuilder builder = new SAXBuilder();
		String res = "<!DOCTYPE html>\n<html lang='es'>\n<head>\n<title>Parser XML Java</title>\n<meta charset = 'utf-8'>\n<link rel='stylesheet' type='text/css' href='estilo.css'>\n</head>\n<body>\n<header>\n<h1>";
		File f = new File(path);
		Document doc = builder.build(new FileInputStream(f));

		Element root = doc.getRootElement();
		res += root.getAttributeValue("denominacion") + "</h1>\n</header>\n";
		List<Element> nodos = root.getChildren();
		res += "<section>\n";
		for (Element nodo : nodos) {
			res += "<h2> Plaza: " + nodo.getAttributeValue("planta") + "-"
					+ nodo.getAttributeValue("fila") + "-"
					+ nodo.getAttributeValue("columna") + "</h2>\n";
			Element internal = nodo.getChild("propietario");
			res += "<article>\n" + "<p>"
					+ internal.getAttributeValue("nombre") + " "
					+ internal.getAttributeValue("apellidos") + " tiene "
					+ internal.getChildren().size() + " coche/s en el parking."
					+ "</p>\n</article>\n";
		}

		res += "</section>\n</body>\n</html>";
		serialize(res);
	}
	
	private void serialize(String res){
		FileWriter fw;
		try {
			fw = new FileWriter("./out/index.html");
			PrintWriter pw = new PrintWriter(fw);
			pw.print(res);
			pw.close();
			fw.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
		
	}

}
