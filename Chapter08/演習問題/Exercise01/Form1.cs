using System.Globalization;
using System.Windows.Forms;

namespace Exercise01 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        //8.1
        private void btEx8_1_Click(object sender, EventArgs e) {
            var today = DateTime.Now;
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            tbDisp.Text = today.ToString("yyyy/MM/dd HH:mm") + "\r\n" +
                        today.ToString("yyyyîNMMåéddì˙Å@HHéûmmï™ssïb") + "\r\n" +
                        today.ToString("ggyyîNMåédì˙ (dddd)", culture);
        }

        //8.2
        private void btEx8_2_Click(object sender, EventArgs e) {
            var today = DateTime.Now;

            foreach (var dayofweek in Enum.GetValues(typeof(DayOfWeek))) {
                var nextweek = (DateTime)NextWeek(today, (DayOfWeek)dayofweek);
                var txt_now = string.Format("{0:yy/MM/dd}ÇÃéüèTÇÃ{1} :", today, (DayOfWeek)dayofweek);
                var txt_next = string.Format("{0:yy/MM/dd (ddd)}", nextweek);
                tbDisp.Text += txt_now + txt_next + "\r\n";
            }
        }
        private object NextWeek(DateTime date, DayOfWeek dayofweek) {
            var nextweek = date.AddDays(7);
            var day = (int)dayofweek - (int)date.DayOfWeek;
            return nextweek.AddDays(day);
        }

        //8.3
        private void btEx8_3_Click(object sender, EventArgs e) {
            var tw = new TimeWach();
            tw.Start();
            Thread.Sleep(1000);
            TimeSpan duration = tw.Stop();
            var str = String.Format("èàóùéûä‘ÇÕ{0}É~ÉäïbÇ≈ÇµÇΩ", duration.TotalMilliseconds);
            tbDisp.Text = str;
        }
    }

    class TimeWach {
        private DateTime _time;

        public void Start() {
            _time = DateTime.Now;
        }

        public TimeSpan Stop() {
            return DateTime.Now - _time;
        }
    }
}
