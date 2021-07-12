using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public abstract class Neuron
    {
        public Neuron[] InputSignals;
        public Neuron OutputSignal;

        public abstract int[] Think();

    }

    public class Eye : Neuron
    {
        public Direction8 direction { private set; get; }
        Field field;

        public override int[] Think()
        {
            return new int[] { GetWall(), GetApple(), GetSelf() };
        }

        public Eye(Direction8 direction, Field field)
        {
            this.field = field;
            this.direction = direction;
        }

        int GetWall()
        {
            Point direct = field.Snake.Body[0];
            int i = 0;
            while (IsInRange(direct))
            {
                direct = direct.Sum(direction.Vector);
                i++;
            }
            return i;
        }

        int GetSelf()
        {
            Point direct = field.Snake.Body[0];
            int i = 0;
            while (IsInRange(direct))
            {
                direct = direct.Sum(direction.Vector);
                for (int j = 1; j < field.Snake.Body.Count; j++)
                {
                    if (direct == field.Snake.Body[j])
                        return i;
                }
                i++;
            }
            return -1;
        }

        int GetApple()
        {
            Point direct = field.Snake.Body[0];
            int i = 0;
            while (IsInRange(direct))
            {
                direct = direct.Sum(direction.Vector);
                for (int j = 1; j < field.Snake.Body.Count; j++)
                {
                    if (direct == field.Apple)
                        return i;
                }
                i++;
            }
            return -1;
        }

        bool IsInRange(Point p) {return p.X >= 0 && p.X < field.Width && p.Y >= 0 && p.Y < field.Height;}
    }
}
