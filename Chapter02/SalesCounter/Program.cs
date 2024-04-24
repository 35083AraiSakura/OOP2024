using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesCounter {
    internal class Program {
        static void Main(string[] args) {


            List<Sale> sales = ReadSales(@"C:\Users\infosys\source\repos\OOP2024\Chapter02\SalesCounter\bin\Debug\data\Sales.csv");

            foreach (Sale sale in sales) {
                //Console.WriteLine(sale.ShopName+" "+sale.productCategory+" "+ sale.Amount);
                //Console.WriteLine("店名 {0} カテゴリー {1} 売り上げ {2}", sale.ShopName, sale.productCategory, sale.Amount);
                Console.WriteLine($"店名 {sale.ShopName} カテゴリー {sale.productCategory} 売り上げ {sale.Amount}" );
            }
        }


        //売上データを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {
            List<Sale> sales = new List<Sale>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines) {
                string[] items = line.Split(',');
                Sale sale = new Sale {
                    ShopName = items[0],
                    productCategory = items[1],
                    Amount = int.Parse(items[2]),
                };
                sales.Add(sale);
            }
            return sales;
        }

    }
}
