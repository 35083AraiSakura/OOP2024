using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

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
            //未入力だったら...
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
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



        //入力履歴を登録_記録者(重複なし)
        private void setcbAuthor(string author) {
            if (!cbAuthor.Items.Contains(author))
                cbAuthor.Items.Add(author);
        }

        //入力履歴を登録_車名(重複なし)
        private void setcbCarName(string carName) {
            if (!cbAuthor.Items.Contains(carName))
                cbCarName.Items.Add(carName);
        }

        //選択をクリア
        private void inputItemsAllCrear() {
            dtpDate.Value = DateTime.Now;
            cbAuthor.Text = "";
            SetMakerRadioButton(CarReport.MakerGroup.なし);
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
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
                    rbOther.Checked = true;
                    break;
                case CarReport.MakerGroup.なし:
                    rbToyota.Checked = false;
                    rbNissan.Checked = false;
                    rbHonda.Checked = false;
                    rbSubaru.Checked = false;
                    rbInport.Checked = false;
                    rbOther.Checked = false;
                    break;
            }
        }


        //開くボタン_Pic
        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        //削除ボタン_Pic
        private void btPicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        //1回だけ呼ばれるやつ
        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;
        }

        //押したら表示
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

        //削除ボタン_Report
        private void btDeleteReport_Click(object sender, EventArgs e) {
            //データがなかったら...
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) {
                tslbMessage.Text = "Error";
                return;
            }
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
            dgvCarReport.ClearSelection();//クリア
            inputItemsAllCrear();
        }

        //修正ボタン_Report
        private void btModifyReport_Click(object sender, EventArgs e) {
            //データがなかったら...
            if ((dgvCarReport.CurrentRow == null) 
                || (!dgvCarReport.CurrentRow.Selected)) {
                tslbMessage.Text = "Error";
                return;
            }
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }


            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioBottonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;

            dgvCarReport.Refresh();//更新
            dgvCarReport.ClearSelection();//クリア
            inputItemsAllCrear();
        }

        //エラー解除_記録者
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
        //エラー解除_車名
        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
    }
}
