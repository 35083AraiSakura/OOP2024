using SampleApp;
using System;

namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);
            Product daihuku = new Product(123, "大福", 250);
            Product dorayaki = new Product(98, "どら焼き", 210);


            int karintoPrice = karinto.Price;  //税抜きの金額
            int karintoTaxincluded = karinto.GetPriceIncludingTax();   //税込みの金額

            int daihukuPrice = daihuku.Price;
            int daihukuTaxincluded = daihuku.GetPriceIncludingTax();   //税込みの金額

            int dorayakiPrice = dorayaki.Price;  //税抜きの金額
            int dorayakiTaxincluded = dorayaki.GetPriceIncludingTax();   //税込みの金額


            Console.WriteLine(karinto.Name + "の税込金額" + karintoTaxincluded + "円【税抜き" + karintoPrice + "円】");
            Console.WriteLine(daihuku.Name + "の税込金額" + daihukuTaxincluded + "円【税抜き" + daihukuPrice + "円】");
            Console.WriteLine($"{dorayaki.Name}の税込金額{dorayakiTaxincluded}円【税抜き{dorayakiPrice}円】");
        }
    }
}