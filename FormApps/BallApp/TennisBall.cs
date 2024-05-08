using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BallApp {
    internal class TennisBall : Obj {

        public TennisBall(double xp, double yp)
            : base(xp - 12, yp - 12, @"Picture\tennis_ball.png") {
            MoveX = 5;     //移動量設定 
            MoveY = 5;
        }

        public override bool Move() {
            if (PosX > 750 || PosX < 0) {
                MoveX = -MoveX;
            }
            if (PosY > 500 || PosY < 0) {
                MoveY = -MoveY;
            }

            PosX -= MoveX;
            PosY += MoveY;

            return true;
        }
    }
}
