using System;

namespace DistanceConverter {
    public class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom") {
                //フィートからメートルへの対応表を出力
                PrintFeetToMeterList(int.Parse(args[0]), 10);
            } else {
                //メートルからフィートへの対応表を出力
                PrintMeterToFeetList(1, 10);
            }
        }


        private static void PrintFeetToMeterList(int start, int stop) {
            FeetConverter fc= new FeetConverter();
            for (int feet = start; feet <= stop; feet++) {
                double meter = fc.ToMeter(feet);
                Console.WriteLine("{0} ft = {1:0.0000} m", feet, meter);
            }
        }

        private static void PrintMeterToFeetList(int start, int stop) {
            FeetConverter fc = new FeetConverter();
            for (int meter = start; meter <= stop; meter++) {
                double feet = fc.FromMeter(meter);
                Console.WriteLine("{0} m = {1:0.0000} ft", meter, feet);
            }
        }        
    }
}
