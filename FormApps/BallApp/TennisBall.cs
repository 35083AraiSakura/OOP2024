using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BallApp {
    internal class TennisBall : Obj {
        public static int tennis_count { get; set; }
        Random rand = new Random();

        public TennisBall(double xp, double yp)
            : base(xp - 12, yp - 12, @"Picture\tennis_ball.png") {
            MoveX = rand.Next(-10,10);     //移動量設定 
            MoveY = rand.Next(-10,10);

            tennis_count++;
        }

        public override bool Move() {
            if (PosX > 750 || PosX < 0) {
                MoveX = -MoveX;
            }
            if (PosY > 500 || PosY < 0) {
                MoveY = -MoveY;
            }

            PosX += MoveX;
            PosY += MoveY;

            return true;
        }

        public override bool Move(Keys direction) {
            return true;
        }
    }
}
