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
        Snake snake = null;
        public Snake Snake 
        { set {
                snake = value;
                foreach (Point part in snake.Body)
                    FieldMatrix[part.X, part.Y] = part;
            }
            get
            {
                return snake;
            }
        }
        public Point[,] FieldMatrix{set; get;}
        public int Width { private set; get; }
        public int Height { private set; get; }

        public int WidthInPixels { get { return Width * PixelX; } }
        public int HeightInPixels { get { return Height * PixelY; } }

        public int PixelX { set; get; }
        public int PixelY { set; get; }

        public Field(int Width, int Height, int PixelX, int PixelY, Snake snake)
        {
            this.Width = Width;
            this.Height = Height;
            this.PixelX = PixelX;
            this.PixelY = PixelY;

            FieldMatrix = new Point[Width, Height];
            Snake = snake;
        }

        public void SnakeRefresh() => Snake = Snake;
    }
}
