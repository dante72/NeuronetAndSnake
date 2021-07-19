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
        public List<Neuron> InputSignals = new List<Neuron>();
        //public Neuron OutputSignal;

        public abstract Matrix Think();

    }

    public class Eye : Neuron
    {
        public Direction8 direction { private set; get; }
        Field field;

        public override Matrix Think()
        {
            return new Matrix(1, 3, 1.0f / GetWall(), 1.0f / GetApple(), 1.0f / GetSelf());
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
                i++;
                direct = direct.Sum(direction.Vector);
                for (int j = 1; j < field.Snake.Body.Count; j++)
                {
                    if (direct == field.Snake.Body[j])
                        return i;
                }

            }
            return -1;
        }

        int GetApple()
        {
            Point direct = field.Snake.Body[0];
            int i = 0;
            while (IsInRange(direct))
            {
                i++;
                direct = direct.Sum(direction.Vector);
                if (direct == field.Apple)
                    return i;

            }
            return -1;
        }

        bool IsInRange(Point p) { return p.X >= 0 && p.X < field.Width && p.Y >= 0 && p.Y < field.Height; }
    }

    public class Hidden : Neuron
    {
        Matrix Weights;
        public Direction Direction;
        public Hidden(Matrix Weights, Direction Direction, params Neuron[] neurons)
        {
            this.Weights = Weights;
            this.Direction = Direction;
            foreach (Neuron neuron in neurons)
                InputSignals.Add(neuron);
        }

        public override Matrix Think()
        {
            float[,] m = new float[InputSignals.Count, 3];
            for (int i = 0; i < InputSignals.Count; i++)
                for (int j = 0; j < InputSignals[i].Think().Colums; j++)
                    m[i, j] = InputSignals[i].Think().Content[0, j];

            return new Matrix(m).Mult(Weights.Transpose());
        }
    }

    public class OutputNeuron : Neuron
    {
        public OutputNeuron(params Neuron[] neurons)
        {
            foreach (Neuron neuron in neurons)
                InputSignals.Add(neuron);
        }
        public  Direction ResultDirection()
        {
            Neuron max = InputSignals[0];

            for (int i = 1; i < InputSignals.Count; i++)
                if (max.Think().ElemSum() < InputSignals[i].Think().ElemSum())
                    max = InputSignals[i];

            return ((Hidden)max).Direction;
        }

        public override Matrix Think()
        {
            throw new NotImplementedException();
        }
    }
}
