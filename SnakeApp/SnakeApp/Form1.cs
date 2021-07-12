using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;

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
            field.AddApple();


            timer1.Interval = 100;
            timer1.Enabled = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, field.WidthInPixels, field.HeightInPixels));
            foreach(Point part in field.Snake.Body)
                e.Graphics.FillRectangle(Brushes.White, new Rectangle(part.X * field.ScaleX, part.Y * field.ScaleY, field.ScaleX, field.ScaleY));
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(field.Apple.X * field.ScaleX, field.Apple.Y * field.ScaleY, field.ScaleX, field.ScaleY));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (field.Snake.Body[0] != field.Apple)
                field.Snake.Move();
            else
            {
                field.AddApple();
                field.Snake.Eat();
            }
            if (field.GameOver())
            {
                field.Snake = new Snake(4, new Point(0, 0), Direction.Down);
                field.AddApple();
            }

            //Eye eye = new Eye(Direction8.Down, field);
            //int[] arr = eye.Think();
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Up:
                    field.Snake.HeadDirection = Direction.Up;
                    break;
                case Keys.Right:
                    field.Snake.HeadDirection = Direction.Right;
                    break;
                case Keys.Down:
                    field.Snake.HeadDirection = Direction.Down;
                    break;
                case Keys.Left:
                    field.Snake.HeadDirection = Direction.Left;
                    break;
            }
        }
    }
}
