using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var xdoc = XDocument.Load("novelists.xml");
            var xmlements = xdoc.Root.Elements()
                .OrderByDescending(x => (DateTime)x.Element("birth")).ToList();


            foreach (var xnovelist in xmlements) {
                var xname = xnovelist.Element("name");              //要素の取得
                var xworks = xnovelist.Element("masterpieces")
                    .Elements("Title")
                    .Select(x => x.Value);

                Console.WriteLine("{0} - {1}", xname.Value, string.Join(",", xworks));
            }
        }
    }
}

//.Where(x => ((DateTime)x.Element("birth")).Year >= 1900);
//var xkana = xname.Attribute("kana");                //属性の取得
//var birth = (DateTime)xnovelist.Element("birth");   //要素の取得