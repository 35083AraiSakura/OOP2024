using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("文字列を入力：");
            var letA = Console.ReadLine();
            Console.Write("文字列を入力：");
            var letB = Console.ReadLine();

            if (String.Compare(letA, letB, true) == 0) {
                Console.WriteLine("文字列は等しい");
            } else {
                Console.WriteLine("文字列は等しくない");
            }
        }
    }
}
