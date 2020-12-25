using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixCalculator
{
    public class Matrix
    {
        double[,] MatrixForCounting;
        //public char Symbol { get; set; }
        public char Symbols { get; set; }


        public Matrix()
        { }
        public Matrix(double[,] matrix)
        {
            if (matrix != null)
            {
                if (matrix.GetLength(0) > 1 && matrix.GetLength(1) > 1)
                {
                    MatrixForCounting = matrix;
                }
                else
                {
                    throw new Exception("Матрица должна иметь больше 1-ого столбца и 1-ой строки");
                }
            }
            else
            {
                throw new NullReferenceException();

            }
        }

        public Matrix(int x, int y)
        {
            if (x > 1 & y > 1)
            {
                MatrixForCounting = new double[x, y];
            }
            else
            {
                throw new Exception("Матрица должна иметь больше 1-ого столбца и 1-ой строки");
            }
        }

        public int ReturnColumn
        {
            get
            {
                return MatrixForCounting.GetLength(0);
            }
        }

        public int ReturnRow
        {
            get
            {
                return MatrixForCounting.GetLength(1);
            }
        }

        /* http://sauron.org.ua/post/58 */

        public double this[int i, int j]
        {
            get
            {
                return MatrixForCounting[i, j];
            }
            set
            {
                MatrixForCounting[i, j] = value;
            }
        }

        public static Matrix operator +(Matrix x, Matrix y)
        {
            return Sum(x, y);
        }

        public static Matrix operator -(Matrix x, Matrix y)
        {
            return Subtraction(x, y);
        }

        public static Matrix operator *(Matrix x, Matrix y
            )
        {
            return Multiplication(x, y);
        }

        public static Matrix Sum(Matrix x, Matrix y)
        {

            Matrix SummationMatrix = new Matrix(x.ReturnColumn, y.ReturnRow);
            if (x != null && y != null)
            {
                for (int i = 0; i < y.ReturnColumn; i++)
                {
                    for (int j = 0; j < x.ReturnRow; j++)
                    {
                        SummationMatrix[i, j] += x[i, j] + y[i, j];
                    }
                }
            }
            else
            {
                new NullReferenceException();
            }

            return SummationMatrix;
        }

        public static Matrix Subtraction(Matrix x, Matrix y)
        {

            Matrix SubtractMatrix = new Matrix(x.ReturnColumn, y.ReturnRow);
            for (int i = 0; i < x.ReturnColumn; i++)
            {
                for (int j = 0; j < y.ReturnRow; j++)
                {
                    SubtractMatrix[i, j] += x[i, j] - y[i, j];
                }
            }
            return SubtractMatrix;
        }

        public static Matrix Multiplication(Matrix x, Matrix y)
        {
            Matrix MultiplyingMatrix = new Matrix(x.ReturnColumn, y.ReturnRow);
            for (int i = 0; i < y.ReturnRow; i++)
            {
                for (int j = 0; j < x.ReturnColumn; j++)
                {
                    for (int k = 0; k < y.ReturnRow; k++)
                    {
                        MultiplyingMatrix[i, j] += x[i, k] * y[k, j];
                    }
                }
            }
            return MultiplyingMatrix;
        }

        public void OutputOfSolutionResults()
        {
            double[,] MatrixForOutput = MatrixForCounting;

            for (int i = 0; i < MatrixForOutput.GetLength(0); ++i, Console.WriteLine())
            {
                for (int j = 0; j < MatrixForOutput.GetLength(1); ++j)
                {
                    Console.Write("{0} ", MatrixForOutput[i, j]);
                }
            }
        }
        // #region Equals and GetHashCode


        public override bool Equals(object obj)
        {
            //if (obj == null)
            //    return false;
            Matrix item = obj as Matrix;

            //if (item as Matrix == null)
            //    return false;

            if ((ReturnRow & ReturnColumn) == (item.MatrixForCounting.GetLength(0) & item.MatrixForCounting.GetLength(1)))
            {
                //for (int i = 0; i < item.MatrixForCounting.GetLength(0); i++)
                //{
                //    for (int j = 0; j < item.MatrixForCounting.GetLength(1); j++)
                //    {
                bool matr = item.MatrixForCounting.Equals(MatrixForCounting);
                //if (item.MatrixForCounting[i, j] != MatrixForCounting[i, j])
                //{
                //    return false;
                //}
                //    }
                //}

            }
            return true;
        }
        //  #endregion
    }
}
