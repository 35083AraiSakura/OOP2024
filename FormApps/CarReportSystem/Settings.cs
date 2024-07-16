using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {
        private static Settings? instance;  //自分自身のインスタンス

        public int MainForColor { get; set; }

        //コンストラクタ(privateにすることによりnewできなくなる)
        private Settings() { }

        //インスタンスを返却するメソッド
        public static Settings getinstance() {
            if(instance == null) {
                instance=new Settings();
            }
            return instance;
        }
    }
}
