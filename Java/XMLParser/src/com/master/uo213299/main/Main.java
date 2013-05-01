package com.master.uo213299.main;

import java.io.IOException;

import org.jdom.JDOMException;

import com.master.uo213299.business.Builder;



public class Main {

	
	public static void main(String[] args) {
		
		System.out.println("Bienvenido al XMLParser, este proyecto generará un HTML tomando como fuente el fichero XML del ejercicio 1");
		
		Builder b = new Builder("./resources/ejercicio1.xml");
		
		try {
			b.build();
		} catch (JDOMException | IOException e) {
			e.printStackTrace();
		}
		
		System.out.println("HTML generado.");
		
	}

}
