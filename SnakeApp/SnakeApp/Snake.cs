using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    class Snake
    {
        public List<Point> Body { set; get; }
        public Direction HeadDirection { set; get; }

        public Snake(int SnakeSize, Point StartPoint, Direction HeadDirection)
        {
            Body = new List<Point>();
            this.HeadDirection = HeadDirection;
            for (int i = 0; i < SnakeSize; i++)
                Body.Add(new Point(StartPoint.X, StartPoint.Y));
        }

        public void Move()
        {
            Body.Insert(0, Body[0].Sum(HeadDirection.Vector));
            Body.RemoveAt(Body.Count - 1);
        }

        public void Eat()
        {
            Body.Insert(0, Body[0].Sum(HeadDirection.Vector));
        }
    }
}
