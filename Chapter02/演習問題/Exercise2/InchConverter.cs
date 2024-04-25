using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2 {
    internal class InchConverter {
        public static readonly double ratio = 0.0254;   //インチ0.914;    ヤード

        //インチからメートルを求める
        public static double ToMeter(double inch) {
            return inch * ratio;
        }

        //メートルからインチを求める
        public static double FromMeter(double inch) {
            return inch / ratio;
        }

    }
}
