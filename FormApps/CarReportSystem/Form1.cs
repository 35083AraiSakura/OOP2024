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
                Picture = pbPicture.Image,
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

        private void SetMakerRadioButton(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbInport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbHonda.Checked = true;
                    break;
            }
        }


        //開くボタン
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        //削除ボタン
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //1回だけ呼ばれるやつ
        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;
        }

        //押したら表示
        private void dgvCarReport_Click(object sender, EventArgs e) {
            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuther.Text = (string)dgvCarReport.CurrentRow.Cells["Auther"].Value;
            SetMakerRadioButton((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image= (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;
        }
    }
}
