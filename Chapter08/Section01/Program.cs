using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var birthday = new DateTime(2004, 4, 19);
            Console.Write("生年月日を入力\n年：");
            var year = int.Parse(Console.ReadLine());
            Console.Write("月：");
            var month = int.Parse(Console.ReadLine());
            Console.Write("日：");
            var day = int.Parse(Console.ReadLine());

            Console.WriteLine();

            var days=new DateTime(year, month, day);
            var week=days.DayOfWeek;

            Console.Write("あなたは");
            switch (week) {
                case DayOfWeek.Sunday:
                    Console.Write("日");
                    break;
                case DayOfWeek.Monday:
                    Console.Write("月");
                    break;
                case DayOfWeek.Tuesday:
                    Console.Write("火");
                    break;
                case DayOfWeek.Wednesday:
                    Console.Write("日");
                    break;
                case DayOfWeek.Thursday:
                    Console.Write("日");
                    break;
                case DayOfWeek.Friday:
                    Console.Write("日");
                    break;
                case DayOfWeek.Saturday:
                    Console.Write("日");
                    break;                
            }
            Console.WriteLine("曜日に生まれました");

            
        }
    }
}
