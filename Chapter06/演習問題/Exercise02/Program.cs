using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
               new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
               new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
               new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
               new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
               new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
               new Book { Title = "私でも分かったASP.NET MVC", Price = 3200, Pages = 453 },
               new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Exercise2_1(books);
            Console.WriteLine("-----");

            Exercise2_2(books);

            Console.WriteLine("-----");

            Exercise2_3(books);
            Console.WriteLine("-----");

            Exercise2_4(books);
            Console.WriteLine("-----");

            Exercise2_5(books);
            Console.WriteLine("-----");

            Exercise2_6(books);

            Console.WriteLine("-----");

            Exercise2_7(books);
        }

        private static void Exercise2_1(List<Book> books) {
            var book = books.First(b => b.Title == "ワンダフル・C#ライフ");
            Console.WriteLine(book.Price + " " + book.Pages);
        }

        private static void Exercise2_2(List<Book> books) {
            var book_count = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(book_count);
        }

        private static void Exercise2_3(List<Book> books) {
            var book = books.Where(b => b.Title.Contains("C#"));
            var book_avg = book.Average(b => b.Pages);
            Console.WriteLine(book_avg);
        }

        private static void Exercise2_4(List<Book> books) {
            var found_book = books.FirstOrDefault(b => b.Price >= 4000);
            Console.WriteLine(found_book.Title);
        }

        private static void Exercise2_5(List<Book> books) {
            var found_book = books.Where(b => b.Price < 4000);
            var max_book = found_book.Max(b => b.Pages);

            Console.WriteLine(max_book);
        }

        private static void Exercise2_6(List<Book> books) {
            var found_book = books.Where(b => b.Pages >= 400);
            var sort_book = found_book.OrderByDescending(b => b.Price);

            foreach (var book in sort_book) {
                Console.WriteLine(book.Title + " " + book.Price + "円");
            }
        }

        private static void Exercise2_7(List<Book> books) {
            var book = books.Where(b => b.Title.Contains("C#")).Where(b => b.Price >= 4000);

            foreach (var item in book)
            {
                Console.WriteLine(item.Title);
            }
            
        }
    }
}
