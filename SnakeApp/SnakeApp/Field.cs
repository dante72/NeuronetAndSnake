using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    class Field
    {
        public Snake Snake { set; get; }
        public Point Apple { set; get; }
        public int Width { private set; get; }
        public int Height { private set; get; }
        public int WidthInPixels { get { return Width * ScaleX; } }
        public int HeightInPixels { get { return Height * ScaleY; } }
        public int ScaleX { set; get; }
        public int ScaleY { set; get; }

        public Field(int Width, int Height, int PixelX, int PixelY, Snake snake)
        {
            this.Width = Width;
            this.Height = Height;
            this.ScaleX = PixelX;
            this.ScaleY = PixelY;
            Snake = snake;
        }

        public void AddApple()
        {
            bool flag;
            int x, y;
            do
            {
                flag = false;
                x = Rng.Random.Next(0, Width);
                y = Rng.Random.Next(0, Height);
                foreach (Point part in Snake.Body)
                {
                    if (x == part.X && y == part.Y)
                    {
                        flag = true;
                        break;
                    }
                }
            } while (flag);

            Apple = new Point(x, y);
        }

        bool CheckNotEatSelf()
        {
            for (int i = 1; i < Snake.Body.Count; i++)
                if (Snake.Body[0] == Snake.Body[i])
                    return false;
            return true;
        }

        bool SnakeNotEscaped()
        {
            if (Snake.Body[0].X >= 0 && Snake.Body[0].X < Width && Snake.Body[0].Y >= 0 && Snake.Body[0].Y < Height)
                return true;
            return false;
        }

        public bool GameOver()
        {
            if (SnakeNotEscaped() && CheckNotEatSelf())
                return false;
            return true;
        }
    }
}
