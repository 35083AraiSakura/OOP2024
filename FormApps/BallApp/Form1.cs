using System.Diagnostics.Eventing.Reader;
namespace BallApp {
    public partial class Form1 : Form {
        //Listコレクション
        private List<Obj> balls = new List<Obj>();        //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();        //表示用

        //コンストラクタ
        public Form1() {
            InitializeComponent();
        }

        //フォームが最初にロードされるときに一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {

        }

        private void timer1_Tick(object sender, EventArgs e) {
            for (int i = 0; i < balls.Count; i++) {
                balls[i].Move();
                pbs[i].Location = new Point((int)balls[i].PosX, (int)balls[i].PosY);
            }
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            PictureBox pb = new PictureBox(); //画像を表示するコントロール
            Obj ball = null;

            //サッカーボール
            if (e.Button == MouseButtons.Left) {
                ball = new SoccerBall(e.X, e.Y);
                pb.Size = new Size(50, 50);
            }

            //テニスボール
            else if (e.Button == MouseButtons.Right) {
                ball = new TennisBall(e.X, e.Y);
                pb.Size = new Size(25, 25);
            }


            pb.Image = ball.Image;
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;
            timer1.Start();

            balls.Add(ball);
            pbs.Add(pb);
            this.Text = "BallApp SoccerBall: " + SoccerBall.soccer_count + "TennisBall:" + TennisBall.tennis_count;

        }
    }
}
