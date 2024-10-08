﻿using SampleEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SampleEntityFramework {
    internal class Program {
        static void Main(string[] args) {
            DisplayAllBooks_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();

            //AddAuthors();
            //AddBooks();
            //InsertBooks();

            Console.ReadLine();
        }

        //タイトルの長さ
        static void DisplayAllBooks_3() {
            using (var db = new BooksDbContext()) {
                var books = db.Books.Where(b => b.Title.Length == db.Books.Max(x => x.Title.Length));
                //db.Books.Select(b => b.Title).Max();

                foreach (var book in books) {
                    Console.WriteLine(book.Title);
                }

            }
        }

        //発行年古い順
        private static void Exercise1_4() {
            using (var db = new BooksDbContext()) {
                var books = db.Books.OrderBy(b => b.PublishedYear).Include(nameof(Author)).Take(3);

                foreach (var book in books) {
                    Console.WriteLine($"{book.Title} {book.PublishedYear} {book.Author.Name}");
                }
            }
        }

        //タイトルと発行日　著者ごと(降順
        private static void Exercise1_5() {
            using (var db = new BooksDbContext()) {
                var authors = db.Authors.OrderByDescending(a => a.Birthday).ToList();
                foreach (var author in authors) {
                    Console.WriteLine($"{author.Name}");
                    foreach (var book in author.Books) {
                        Console.WriteLine($"{book.Title} {book.PublishedYear}");
                    }
                    Console.WriteLine();
                }
            }

        }

        static void InsertBooks() {
            using (var db = new BooksDbContext()) {
                var book1 = new Book {
                    Title = "坊ちゃん",
                    PublishedYear = 2003,
                    Author = new Author {
                        Birthday = new DateTime(1867, 2, 9),
                        Gender = "M",
                        Name = "夏目漱石",
                    }
                };

                db.Books.Add(book1);

                var book2 = new Book {
                    Title = "人間失格",
                    PublishedYear = 1990,
                    Author = new Author {
                        Birthday = new DateTime(1909, 6, 19),
                        Gender = "M",
                        Name = "太宰治",
                    }
                };
                db.Books.Add(book2);
                db.SaveChanges();   //データベース更新

            }
        }

        static IEnumerable<Book> GetBooks() {
            using (var db = new BooksDbContext()) {
                return db.Books
                    //.Where(book => book.Author.Name.StartsWith("夏目"))
                    .ToList();
            }
        }

        static void DisplayAllBooks_2() {
            using (var db = new BooksDbContext()) {
                foreach (var book in db.Books.ToList()) {
                    Console.WriteLine("{0} {1} {2} {3:yyyy/mm/dd}", book.Title, book.PublishedYear
                                        , book.Author.Name, book.Author.Birthday);
                }
            }
        }

        private static void AddAuthors() {
            using (var db = new BooksDbContext()) {
                //var author1 = new Author {
                //    Birthday = new DateTime(1878, 12, 7),
                //    Gender = "F",
                //    Name = "与謝野晶子",
                //};
                //db.Authors.Add(author1);
                //var author2 = new Author {
                //    Birthday = new DateTime(1896, 8, 27),
                //    Gender = "M",
                //    Name = "宮沢賢治",
                //};
                //db.Authors.Add(author2);




                var author3 = new Author {
                    Birthday = new DateTime(1888, 12, 26),
                    Gender = "M",
                    Name = "菊池寛",
                };
                db.Authors.Add(author3);
                var author4 = new Author {
                    Birthday = new DateTime(1899, 6, 14),
                    Gender = "M",
                    Name = "川端康成",
                };
                db.Authors.Add(author4);
                db.SaveChanges();
            }
        }

        private static void AddBooks() {
            using (var db = new BooksDbContext()) {
                //var Author1 = db.Authors.Single(a => a.Name == "与謝野晶子");
                //var book1 = new Book {
                //    Title = "みだれ髪",
                //    PublishedYear = 2000,
                //    Author = Author1,
                //};
                //db.Books.Add(book1);
                //var Author2 = db.Authors.Single(a => a.Name == "宮沢賢治");
                //var book2 = new Book {
                //    Title = "銀河鉄道の夜",
                //    PublishedYear = 1989,
                //    Author = Author2,
                //};
                //db.Books.Add(book2);




                var Author3 = db.Authors.Single(a => a.Name == "夏目漱石");
                var book3 = new Book {
                    Title = "こころ",
                    PublishedYear = 1991,
                    Author = Author3,
                };
                db.Books.Add(book3);
                var Author4 = db.Authors.Single(a => a.Name == "川端康成");
                var book4 = new Book {
                    Title = "伊豆の踊子",
                    PublishedYear = 2003,
                    Author = Author4,
                };
                db.Books.Add(book4);
                var Author5 = db.Authors.Single(a => a.Name == "菊池寛");
                var book5 = new Book {
                    Title = "真珠夫人",
                    PublishedYear = 2002,
                    Author = Author5,
                };
                db.Books.Add(book5);
                var Author6 = db.Authors.Single(a => a.Name == "宮沢賢治");
                var book6 = new Book {
                    Title = "注文の多い料理店",
                    PublishedYear = 2000,
                    Author = Author6,
                };
                db.Books.Add(book6);
                db.SaveChanges();
            }
        }
    }
}
