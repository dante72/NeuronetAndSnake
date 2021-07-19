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
        public List<OutputNeuron> output = new List<OutputNeuron>();

        public Matrix Weights = new Matrix(1, 3, -1f, 1f, -0.5f);
        public Brain(Field field)
        {
            foreach (Direction8 dir in Direction8.All)
            {
                Eye eye = new Eye(dir, field);
                eyes.Add(eye);
            }

            hiddens.Add(new Hidden(Weights, Direction.Up, eyes[7], eyes[0], eyes[1]));
            hiddens.Add(new Hidden(Weights, Direction.Right, eyes[1], eyes[2], eyes[3]));
            hiddens.Add(new Hidden(Weights, Direction.Down, eyes[3], eyes[4], eyes[5]));
            hiddens.Add(new Hidden(Weights, Direction.Left, eyes[5], eyes[6], eyes[7]));

            output.Add(new OutputNeuron(hiddens[0], hiddens[1], hiddens[2], hiddens[3]));

        }
        public Direction Think()
        {
            return output[0].ResultDirection();
        }
    }
}
