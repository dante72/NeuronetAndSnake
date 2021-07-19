using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public class Matrix
    {
        public float[,] Content { private set; get; }
        public int Colums { private set; get; }
        public int Rows { private set; get; }
        public Matrix(int rows, int cols, params float[] content)
        {
            Colums = cols;
            Rows = rows;

            int k = 0;
            Content = new float[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (k < content.Length)
                        Content[i, j] = content[k++];
                    else
                        Content[i, j] = 0;
                }
        }
        public Matrix(float[,] content)
        {
            Rows = content.GetLength(0);
            Colums = content.GetLength(1);

            Content = new float[Rows, Colums];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Colums; j++)
                    Content[i, j] = content[i, j];
        }

        public Matrix Transpose()
        {
            float[,] matrix = new float[Colums, Rows];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Colums; j++)
                    matrix[j, i] = Content[i, j];

            return new Matrix(matrix);
        }

        public Matrix Mult(Matrix matrix)
        {
            float[,] m = new float[Rows, matrix.Colums];
            if (Colums == matrix.Rows)
            {
                for (int i = 0; i < Rows; i++)
                    for (int j = 0; j < matrix.Colums; j++)
                    {
                        m[i, j] = 0;
                        for (int k = 0; k < Colums; k++)
                            m[i, j] += Content[i, k] * matrix.Content[k, j];
                    }
            }
            else
                throw new ArgumentException();
            return new Matrix(m);
        }

        public Matrix Unity(params Matrix[] m)
        {
            int cols = m[0].Colums;
            for (int i = 1; i < m.Length; i++)
                if (m[i].Colums != cols)
                    throw new ArgumentException("The matrices must have the same length!");

            int rows = 0;
            for (int i = 0; i < m.Length; i++)
                rows += m[i].Rows;

            float [,]matrix = new float[rows, cols];
            int mrow = 0;
            for (int i = 0; i < m.Length; i++)
                for (int j = 0; j < m[i].Rows; j++)
                {
                    for (int k = 0; k < m[k].Colums; k++)
                        matrix[mrow, k] = m[i].Content[j, k];
                    mrow++;
                }
            return new Matrix(matrix);
        }

        public float ElemSum()
        {
            float sum = 0;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Colums; j++)
                    sum += Content[i, j];
            return sum;
        }
    }
}
