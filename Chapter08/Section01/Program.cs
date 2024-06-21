using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

            var days = new DateTime(year, month, day);

            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            //あなたは平成×年×月×日×曜日に生まれました
            Console.Write("あなたは");
            Console.Write(days.ToString("ggyy年M月d日", culture));
            Console.Write(days.ToString("dddd"));
            Console.WriteLine("に生まれました");

            //あなたは生まれてから今日で×日目です
            var today = DateTime.Today;
            TimeSpan diff = today - days;
            Console.WriteLine("あなたは生まれてから今日で{0}日目です", diff.Days + 1);
        }
    }
}
