using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var file = "sample.xml";
            Exercise1_1(file);
            Console.WriteLine();
            Exercise1_2(file);
            Console.WriteLine();
            Exercise1_3(file);
            Console.WriteLine();

            var newfile = "sports.xml";
            Exercise1_4(file, newfile);
        }

        private static void Exercise1_1(string file) {
            var xdoc = XDocument.Load(file);
            var xmlements = xdoc.Root.Elements();

            foreach (var xsport in xmlements) {
                var xname = xsport.Element("name");
                var xmenber = xsport.Element("teammembers");
                Console.WriteLine($"{xname.Value} {xmenber.Value}");
            }
        }

        private static void Exercise1_2(string file) {
            var xdoc = XDocument.Load(file);
            var xmlememts = xdoc.Root.Elements()
                .OrderBy(x => (double)x.Element("firstplayed"));

            foreach (var xsport in xmlememts) {
                var xkana = xsport.Element("name").Attribute("kanji");
                var firstplayed = (double)xsport.Element("firstplayed");

                Console.WriteLine($"{xkana.Value}({firstplayed})");
            }
        }

        private static void Exercise1_3(string file) {
            var xdoc = XDocument.Load(file);
            var maxMembers = xdoc.Root.Elements().OrderByDescending(x => (double)x.Element("teammembers")).First();
            var max = maxMembers.Element("name");

            Console.WriteLine(max.Value);
        }

        private static void Exercise1_4(string file, string newfile) {

            var element = new XElement(file,
                new XElement("name", "サッカー", new XAttribute("kanji", "蹴球")),
                new XElement("teammembers", "11"),
                new XElement("firstplayed", "1863"));
            var xdoc = XDocument.Load(file);
            xdoc.Root.Add(element);

            foreach (var sport in xdoc.Root.Elements()) {
                var name = sport.Element("name");
                var teammembers = (double)sport.Element("teammembers");
                Console.WriteLine("{0} {1}", name.Value, teammembers);
            }
        }
    }
}
