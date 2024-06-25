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
                        today.ToString("yyyy年MM月dd日　HH時mm分ss秒") + "\r\n" +
                        today.ToString("ggyy年M月d日 (dddd)", culture);
        }

        //8.2       
        private void btEx8_2_Click(object sender, EventArgs e) {
            //var today = DateTime.Now;
            //Console.Write("0(日)-6(土)入力：");
            //var week = int.Parse(Console.ReadLine());
            //var nextweek = NextDay(today, week);
            //tbDisp.Text = "次の週の" + week + "曜日は" + nextweek;
        }
        private object NextDay(DateTime today, int week) {
            var days = week - (int)(today.DayOfWeek);
            if (days <= 0)
                days += 7;
            return today.AddDays(days);
        }
    }
}
