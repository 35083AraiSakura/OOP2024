using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            var text_a = "Jackdaws love,my big-sphinx-of_quartz";

            Exercise3_1(text);
            Console.WriteLine("-----");

            Exercise3_2(text);
            Console.WriteLine("-----");

            Exercise3_3(text);
            Console.WriteLine("-----");

            Exercise3_4(text);
            Console.WriteLine("-----");

            Exercise3_5(text);
            Console.WriteLine("-----");

            Exercise3_6(text_a);
        }

        private static void Exercise3_1(string text) {
            //char word = ' ';

            //int cnt = text.Count(f => (f == word));
            //Console.WriteLine(cnt);

            var space = text.Count(c => c == ' ');
            Console.WriteLine(space);
        }

        private static void Exercise3_2(string text) {
            var change = text.Replace("big", "small");
            Console.WriteLine(change);
        }

        private static void Exercise3_3(string text) {
            int count = text.Split(' ').Length;
            Console.WriteLine("単語数：{0}", count);
        }

        private static void Exercise3_4(string text) {
            var words = text.Split(' ').Where(s => s.Length <= 4);
            foreach (var word in words) {
                Console.WriteLine(word);
            }
        }

        private static void Exercise3_5(string text) {
            var words = text.Split(' ').ToArray();

            var sb = new StringBuilder();
            foreach (var word in words) {
                sb.Append(word);
                sb.Append(' ');
            }
            Console.WriteLine(sb);
        }

        private static void Exercise3_6(string text) {
            var array = text.Split(new[] { ' ', ',', '-', '_' }).ToArray();
            foreach (var word in array)
            {
                Console.WriteLine(word);
            }

        }
    }
}
