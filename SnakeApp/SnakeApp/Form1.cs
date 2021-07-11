using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeApp
{
    public partial class Form1 : Form
    {
        Field field;
        public Form1()
        {
            InitializeComponent();
            Snake snake = new Snake(4, new Point(0, 0), Direction.Down);
            field = new Field(40, 40, 20, 20, snake);
            ClientSize = new Size(field.WidthInPixels, field.HeightInPixels);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, field.WidthInPixels, field.HeightInPixels));
            foreach(Point part in field.Snake.Body)
            {
                e.Graphics.FillRectangle(Brushes.White, new Rectangle(part.X, part.Y, field.PixelX, field.PixelY));
            }
        }
    }
}
