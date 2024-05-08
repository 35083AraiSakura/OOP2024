using System.Diagnostics.Eventing.Reader;

namespace BallApp {
    public partial class Form1 : Form {
        private double posX;    //X���W
        private double posY;    //Y���W
        private double moveX;   //�ړ���(X����)
        private double moveY;   //�ړ���(Y����)


        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();

            moveX = moveY = 5;
        }

        //�t�H�[�����ŏ��Ƀ��[�h�����Ƃ��Ɉ�x�������s�����
        private void Form1_Load(object sender, EventArgs e) {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            //���݈ʒu��\��
            this.Text = pbBall.Location.ToString();

            if (pbBall.Location.X > 750 || pbBall.Location.X < 0) {
                //�ړ��ʂ̕����𔽓]
                moveX = -moveX;
            }

            if (pbBall.Location.Y > 500 || pbBall.Location.Y < 0) {
                //�ړ��ʂ̕����𔽓]
                moveY = -moveY;
            }

            posX += moveX;
            posY += moveY;

            pbBall.Location = new Point((int)posX, (int)posY);
        }

        private void pbBall_Click(object sender, EventArgs e) {

        }
    }
}
