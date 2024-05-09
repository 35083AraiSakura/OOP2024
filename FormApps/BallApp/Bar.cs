using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BallApp {
    internal class Bar : Obj {

        public Bar(double xp, double yp)
            : base(xp, yp, @"Picture\bar.png") {
            MoveX = 10;
            MoveY = 0;
        }       

        public override bool Move() {
            return true;
        }

        public override bool Move(Keys direction) {
            if (direction == Keys.Right) {
                PosX += MoveX;
            } else if (direction == Keys.Left) {
                PosX -= MoveX;
            }

            if (PosX > 640 ) {
                PosX = 640;
            }else if(PosX<0) {
                PosX = 0;
            }            


            return true;
        }
    }
}
