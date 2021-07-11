using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public static class PointExtention
    {
        public static Point Sum(this Point p1, Point p2)
        {
            return new Point { X =  p1.X + p2.X, Y = p1.Y + p2.Y};
        }
    }
}
