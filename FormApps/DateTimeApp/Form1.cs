using System.Diagnostics.Metrics;
using System.Windows.Forms;

namespace DateTimeApp {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //今日までの日付
        private void bpDateCount_Click(object sender, EventArgs e) {
            var today = DateTime.Today;
            var days = dtpBirthday.Value;
            TimeSpan diff = today - days;
            //tbDisp.Text = "〇日目";
            tbDisp.Text = (diff.Days + 1) + "日目";
        }

        //X日前
        private void btDayBefore_Click(object sender, EventArgs e) {
            var days = dtpBirthday.Value;
            var day = nudDay.Value;
            var before = days.AddDays(-(double)day);
            tbDisp.Text = before.Year + "年" + before.Month + "月" + before.Day + "日";
        }

        //X日後
        private void btDayAfter_Click(object sender, EventArgs e) {
            var days = dtpBirthday.Value;
            var day = nudDay.Value;
            var after = days.AddDays((double)day);
            tbDisp.Text = after.Year + "年" + after.Month + "月" + after.Day + "日";
        }

        //年齢
        private void btOld_Click(object sender, EventArgs e) {
        //    var days = dtpBirthday.Value;
        //    var today = DateTime.Today;
        //    int age=GetAge(days, today);
        }
    }
}
