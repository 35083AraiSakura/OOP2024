using System.ComponentModel;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //コンストラクタ
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        //追加ボタン
        private void btAddRepote_Click(object sender, EventArgs e) {
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Auther = cbAuther.Text,
                Maker = GetRadioBottonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
            };
            listCarReports.Add(carReport);
        }

        private CarReport.MakerGroup GetRadioBottonMaker() {
            if (rbToyota.Checked == true) {
                return CarReport.MakerGroup.トヨタ;
            }
            if (rbNissan.Checked == true) {
                return CarReport.MakerGroup.日産;
            }
            if (rbHonda.Checked == true) {
                return CarReport.MakerGroup.ホンダ;
            }
            if (rbSubaru.Checked == true) {
                return CarReport.MakerGroup.スバル;
            }
            if (rbInport.Checked == true) {
                return CarReport.MakerGroup.輸入車;
            }
            return CarReport.MakerGroup.その他;
        }
    }
}
