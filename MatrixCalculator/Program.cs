using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MatrixCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixExpressionFileReader text = new MatrixExpressionFileReader();
            //double[,] a = text.ReadMatrixInFile(args[0]);
            //double[,] b = text.ReadMatrixInFile(args[1]);
            //double[,] c = text.ReadMatrixInFile(args[2]);
            Matrix A = new Matrix(text.ReadMatrixInFile(args[0]));
            Matrix B = new Matrix(text.ReadMatrixInFile(args[1]));
            Matrix C = new Matrix(text.ReadMatrixInFile(args[2]));
            string Expression = text.ReadExpression(args[3]);
            Expression AddToTheDictionary = new Expression(Expression, A, B, C);
            AddToTheDictionary.Decision();
            Console.ReadKey();
        }


    }
}
