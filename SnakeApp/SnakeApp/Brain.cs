using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public class Brain
    {
        public List<Eye> eyes = new List<Eye>();
        public List<Hidden> hiddens = new List<Hidden>();
        public Brain(Field field)
        {
            foreach (Direction8 dir in Direction8.All)
            {
                Eye eye = new Eye(dir, field);
                eyes.Add(eye);
            }

            hiddens.Add(new Hidden(Direction.Up, eyes[7], eyes[0], eyes[1]));
            hiddens.Add(new Hidden(Direction.Right, eyes[1], eyes[2], eyes[3]));
            hiddens.Add(new Hidden(Direction.Down, eyes[3], eyes[4], eyes[5]));
            hiddens.Add(new Hidden(Direction.Left, eyes[5], eyes[6], eyes[7]));

        }

        public Direction Think()
        {
            Hidden max = hiddens[0];

            for (int i = 1; i < hiddens.Count; i++)
                if (max.Think().ElemSum() < hiddens[i].Think().ElemSum())
                    max = hiddens[i];

            return max.Direction;
        }
    }
}
