﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            Exercise1_1(numbers);
            Console.WriteLine("-----");

            Exercise1_2(numbers);
            Console.WriteLine("-----");

            Exercise1_3(numbers);
            Console.WriteLine("-----");

            Exercise1_4(numbers);
            Console.WriteLine("-----");

            Exercise1_5(numbers);
        }

        private static void Exercise1_1(int[] numbers) {
            var max = numbers.Max();
            Console.WriteLine(max);
        }

        private static void Exercise1_2(int[] numbers) {
            var last = numbers.Skip(numbers.Length - 2).ToArray();

            foreach (var last_num in last) {
                Console.WriteLine(last_num);
            }
        }

        private static void Exercise1_3(int[] numbers) {
            var strings = numbers.Select(x => x.ToString());

            foreach (var num in strings) {
                Console.WriteLine(num);
            }
        }

        private static void Exercise1_4(int[] numbers) {
            var number = numbers.OrderBy(n => n);
            var take_list = number.Take(3).ToList();

            foreach (var take in take_list) {
                Console.WriteLine(take);
            }

        }

        private static void Exercise1_5(int[] numbers) {
            var dep_numbers = numbers.Distinct();
            var count = dep_numbers.Count(n => n > 10);

            Console.WriteLine(count);
        }
    }
}
