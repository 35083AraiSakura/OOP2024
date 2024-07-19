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
            List<XElement> list = new List<XElement>();
            var xdoc = XDocument.Load(file);
            while (true) {
                Console.Write("名称:");
                var s_name = (Console.ReadLine());
                Console.Write("漢字:");
                var s_kanji = (Console.ReadLine());
                Console.Write("人数:");
                var s_player = (Console.ReadLine());
                Console.Write("起源:");
                var s_first = (Console.ReadLine());

                var element = new XElement(file,
                              new XElement("name", s_name, new XAttribute("kanji", s_kanji)),
                              new XElement("teammembers", s_player),
                              new XElement("firstplayed", s_first));
                list.Add(element);
                Console.WriteLine();
                Console.Write("追加:1 保存:2　> ");
                var judge = int.Parse(Console.ReadLine());

                if (judge == 2)
                    break;
                Console.WriteLine();
            }
            xdoc.Add(list);
            xdoc.Save(newfile);
        }
    }
}
