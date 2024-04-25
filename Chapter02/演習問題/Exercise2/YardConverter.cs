using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    internal class YardConverter {
        public static readonly double ratio = 0.914;    //ヤード

        //インチからメートルを求める
        public static double ToMeter(double yard) {
            return yard * ratio;
        }

        //メートルからインチを求める
        public static double FromMeter(double yard) {
            return yard / ratio;
        }
    }
}
