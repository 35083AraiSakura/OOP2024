using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOffinceDict = new Dictionary<string, string>();
        static void Main(string[] args) {
            String country, ken, select;
            bool judge = true;

            Console.WriteLine("県庁所在地の登録");

            while(true) {
                Console.Write("都道府県：");
                country = Console.ReadLine();
                if (country == null)
                    break;

                Console.Write("県庁所在地：");
                ken = Console.ReadLine();
                if (prefOffinceDict.ContainsKey(country)) {
                    Console.Write("同じ県が登録されています。上書きしますか? Yes/No：");
                    select = Console.ReadLine();
                    if (select == "Yes") {
                        prefOffinceDict.Remove(country);
                        prefOffinceDict.Add(country, ken);
                    } else {
                        break;
                    }
                } else {
                    prefOffinceDict.Add(country, ken);

                }
            }
            Console.WriteLine();




            while (judge) {
                var sel = menu();

                switch (sel) {
                    case 1://一覧表示
                        list_1(prefOffinceDict);
                        break;
                    case 2://検索
                        list_2(prefOffinceDict);
                        break;
                    case 9://終わり
                        judge = false;
                        break;
                }
                Console.WriteLine();
            }
        }



        private static int menu() {
            Console.Write("*メニュー*\n1：一覧表示\n2：検索\n9：終了\n-----------------\n>");
            var sel = int.Parse(Console.ReadLine());
            return sel;
        }

        private static void list_1(Dictionary<string, string> prefOffinceDict) {
            foreach (var item in prefOffinceDict) {
                Console.WriteLine(item.Key + " の県庁所在地は" + item.Value + " です");
            }
        }

        private static void list_2(Dictionary<string, string> prefOffinceDict) {
            Console.Write("都道府県：");
            var contr = Console.ReadLine();
            foreach (var item in prefOffinceDict) {
                if (contr == item.Key) {
                    Console.WriteLine("県庁所在地：" + item.Value);
                }
            }
        }
    }
}
