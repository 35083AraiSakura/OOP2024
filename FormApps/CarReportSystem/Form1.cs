using System.ComponentModel;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports=new BindingList<CarReport>();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        //追加ボタン
        private void btAddRepote_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date=dtpDate.Value,

            };
            listCarReports.Add(carReport);
        }
    }
}
