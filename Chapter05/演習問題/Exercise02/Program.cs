using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("数値を入力：");
            string line = Console.ReadLine();
            int number;

            if (int.TryParse(line, out number)) {
                Console.WriteLine("{0:#,#}", number);
            } else {
                Console.WriteLine("数字文字列ではありません");
            }
        }
    }
}
