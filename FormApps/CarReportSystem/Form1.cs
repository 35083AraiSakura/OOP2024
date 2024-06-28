using System.ComponentModel;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }

        //�ǉ��{�^��
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
                return CarReport.MakerGroup.�g���^;
            }
            if (rbNissan.Checked == true) {
                return CarReport.MakerGroup.���Y;
            }
            if (rbHonda.Checked == true) {
                return CarReport.MakerGroup.�z���_;
            }
            if (rbSubaru.Checked == true) {
                return CarReport.MakerGroup.�X�o��;
            }
            if (rbInport.Checked == true) {
                return CarReport.MakerGroup.�A����;
            }
            return CarReport.MakerGroup.���̑�;
        }
    }
}
