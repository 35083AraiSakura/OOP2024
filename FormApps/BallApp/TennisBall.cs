using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BallApp {
    internal class TennisBall : Obj {
        Random random = new Random();   //乱数

        public static int Count { get; set; }

        public TennisBall(double xp, double yp)
            : base(xp, yp, @"Picture\tennis_ball.png") {

            MoveX = random.Next(-25, 25); //移動量
            MoveY = random.Next(-25, 25); ;

            Count++;
        }

        //戻り値:0...移動 1...下落 2...バー当たる
        public override int Move(PictureBox pbBar, PictureBox pbBall) {
            Rectangle rBar = new Rectangle(pbBar.Location.X, pbBar.Location.Y,pbBar.Width, pbBar.Height);
            Rectangle rBall = new Rectangle(pbBall.Location.X, pbBall.Location.Y,pbBall.Width, pbBall.Height);
            int ret = 0;


            if (PosX > 750 || PosX < 0) {
                //符号を反転
                MoveX = -MoveX;
            }

            if (PosY < 0) {
                //符号を反転
                MoveY = -MoveY;
            }

            //バー
            if (rBar.IntersectsWith(rBall)) {
                MoveY = -MoveY;

                PosX += MoveX;
                PosY += MoveY;

                ret = 2;
            }

            PosX += MoveX;
            PosY += MoveY++;

            //下
            if (PosY > 500)
                ret = 1;

            //移動
            return ret;
        }

        public override bool Move(Keys direction) {
            return true;
        }
    }
}
