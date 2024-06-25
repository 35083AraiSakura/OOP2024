using System.Diagnostics.Metrics;
using System.Windows.Forms;

namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //�����܂ł̓��t
        private void bpDateCount_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            var days = dtpBirthday.Value;
            TimeSpan diff = today - days;
            //tbDisp.Text = "�Z����";
            tbDisp.Text = (diff.Days + 1) + "����";
        }

        //X���O
        private void btDayBefore_Click(object sender, EventArgs e) {
            var days = dtpBirthday.Value;
            var day = nudDay.Value;
            var before = days.AddDays(-(double)day);
            tbDisp.Text = before.Year + "�N" + before.Month + "��" + before.Day + "��";
        }

        //X����
        private void btDayAfter_Click(object sender, EventArgs e) {
            var days = dtpBirthday.Value;
            var day = nudDay.Value;
            var after = days.AddDays((double)day);
            tbDisp.Text = after.Year + "�N" + after.Month + "��" + after.Day + "��";
        }

        //�N��
        private void btOld_Click(object sender, EventArgs e) {
        //    var days = dtpBirthday.Value;
        //    var today = DateTime.Today;
        //    int age=GetAge(days, today);
        }
    }
}
