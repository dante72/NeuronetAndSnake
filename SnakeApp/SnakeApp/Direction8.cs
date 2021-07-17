using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public class Direction8
    {
        public static Direction8 Up = new Direction8(new Point(0, -1));
        public static Direction8 RightUp = new Direction8(new Point(1, -1));
        public static Direction8 Right = new Direction8(new Point(1, 0));
        public static Direction8 RightDown = new Direction8(new Point(1, 1));
        public static Direction8 Down = new Direction8(new Point(0, 1));
        public static Direction8 LeftDown = new Direction8(new Point(-1, 1));
        public static Direction8 Left = new Direction8(new Point(-1, 0));
        public static Direction8 LeftUp = new Direction8(new Point(-1, -1));
        public Point Vector { private set; get; }

        public static Direction8[] All = new Direction8[] { Up, RightUp, Right, RightDown, Down, LeftDown, Left, LeftUp };
        private Direction8(Point Vector)
        {
            this.Vector = Vector;
        }
    }
}
