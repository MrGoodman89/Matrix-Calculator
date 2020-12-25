using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MatrixCalculator
{
    class MatrixExpressionFileReader
    {
        private string[] Row;
        private string[] Column;
        private double[,] MatrixFromFile;

        public double[,] ReadMatrixInFile(string Args)
        {

            string UploadedFile = "";
            StreamReader File = new StreamReader(Args);
            UploadedFile = File.ReadToEnd();
            File.Close();
            Row = UploadedFile.Split('\n');
            Column = Row[0].Split(' ');
            MatrixFromFile = new double[Row.Length, Column.Length];
            double x = 0;
            for (int i = 0; i < Row.Length; i++)
            {
                for (int j = 0; j < Column.Length; j++)
                {
                    x = Convert.ToDouble(Column[j]);
                    MatrixFromFile[i, j] = x;
                }
            }
            return MatrixFromFile;

        }
        public string ReadExpression(string Equation)
        {
            string text = "";
            StreamReader File = new StreamReader(Equation);
            text = File.ReadToEnd();
            File.Close();
            return text;
        }
    }
}
