using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder b = new Builder();
            b.build("../../resources/ejercicio1.xml");
        }
    }
}
