using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

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
            //�����͂�������...
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
                return;
            }

            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioBottonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);

            setcbAuthor(cbAuthor.Text);
            setcbCarName(cbCarName.Text);

            dgvCarReport.ClearSelection();
            inputItemsAllCrear();
        }



        //���͗�����o�^_�L�^��(�d���Ȃ�)
        private void setcbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //���͗�����o�^_�Ԗ�(�d���Ȃ�)
        private void setcbCarName(string carName) {
            if (!cbAuthor.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        //�I�����N���A
        private void inputItemsAllCrear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            SetMakerRadioButton(CarReport.MakerGroup.�Ȃ�);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
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

        private void SetMakerRadioButton(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbInport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
                    rbOther.Checked = true;
                    break;
                case CarReport.MakerGroup.�Ȃ�:
                    rbToyota.Checked = false;
                    rbNissan.Checked = false;
                    rbHonda.Checked = false;
                    rbSubaru.Checked = false;
                    rbInport.Checked = false;
                    rbOther.Checked = false;
                    break;
            }
        }


        //�J���{�^��_Pic
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        //�폜�{�^��_Pic
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //1�񂾂��Ă΂����
        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;
        }

        //��������\��
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;

            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
            SetMakerRadioButton((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["Picture"].Value;
        }

        //�폜�{�^��_Report
        private void btDeleteReport_Click(object sender, EventArgs e) {
            //�f�[�^���Ȃ�������...
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) {
                tslbMessage.Text = "Error";
                return;
            }
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection();//�N���A
            inputItemsAllCrear();
        }

        //�C���{�^��_Report
        private void btModifyReport_Click(object sender, EventArgs e) {
            //�f�[�^���Ȃ�������...
            if ((dgvCarReport.CurrentRow == null) 
                || (!dgvCarReport.CurrentRow.Selected)) {
                tslbMessage.Text = "Error";
                return;
            }
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
                return;
            }


            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioBottonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;

            dgvCarReport.Refresh();//�X�V
            dgvCarReport.ClearSelection();//�N���A
            inputItemsAllCrear();
        }

        //�G���[����_�L�^��
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
        //�G���[����_�Ԗ�
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
    }
}
