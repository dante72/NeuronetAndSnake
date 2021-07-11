using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    class Direction
    {
        public static Direction Up = new Direction(new Point(0, -1));
        public static Direction Right = new Direction(new Point(1, 0));
        public static Direction Down = new Direction(new Point(0, 1));
        public static Direction Left = new Direction(new Point(-1, 0));
        public Point Vector { private set; get; }
        private Direction(Point Vector)
        {
            this.Vector = Vector;
        }
    }
}
