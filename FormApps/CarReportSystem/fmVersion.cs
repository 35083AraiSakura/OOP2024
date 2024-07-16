using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarReportSystem {
    public partial class fmVersion : Form {
        public fmVersion() {
            InitializeComponent();
        }

        //OKボタン
        private void btVersionOK_Click(object sender, EventArgs e) {
            Close();
        }

        //1回だけ呼ばれる
        private void fmVersion_Load(object sender, EventArgs e) {
            var asm = Assembly.GetExecutingAssembly();
            var ver = asm.GetName().Version;
            var text = string.Format($"Ver,{ver.Major}.{ver.Minor}.{ver.Build}.{ver.Revision}");
            lbVersion.Text = text;
        }
    }
}
