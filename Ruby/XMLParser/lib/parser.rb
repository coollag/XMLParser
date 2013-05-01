require 'rexml/document'
class Parser
  #Parsea el xml ejercicio 1
  def parser src

    #Carga el fichero y lo convierte en objeto de REXML (Clase propia del lenguaje Ruby)
    file = File.new(src)
    doc = REXML::Document.new file
    puts 'Bienvenido al XMLParser, este proyecto generara un HTML tomando como fuente el fichero XML del ejercicio 1'
    #Me situo en la raíz
    @xml = doc.root
    @res = "<!DOCTYPE html>\n<html lang='es'>\n<head>\n<title>Parser XML Ruby</title>\n<meta charset = 'utf-8'>\n<link rel='stylesheet' type='text/css' href='estilo.css'>\n</head><body>\n<header>\n<h1>";
    #Obtengo el atributo de la raíz
    @res += @xml.attributes["denominacion"] + "</h1>\n</header>"
    @res +="<section>\n"

    #Esta es la forma de iterar vectores en Ruby, se iteran por las plazas del xml
    @xml.elements.each { |element|
      @res += "<h2> Plaza: " + element.attributes["planta"] + "-"	+ element.attributes["fila"] + "-" + element.attributes["columna"] + "</h2>\n";
			@internal = element.elements["propietario"];
      @res += "<article>\n" + "<p>"	+ @internal.attributes["nombre"] + " " + @internal.attributes["apellidos"] + " tiene " + @internal.elements.size.to_s + " coche/s en el parking." + "</p>\n</article>\n";
    }

    @res += "</section>\n</body>\n</html>";
    #Se serializa el parseo en HTML
    serialize(@res);
   
    puts 'HTML generado'

  end

  #Pasa a fichero de disco el html generado en el metodo parser
  def serialize res
    File.open('../out/index.html', 'w') do |f|
      f.puts res
    end
  end
  
end
