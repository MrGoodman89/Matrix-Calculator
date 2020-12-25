using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixCalculator
{
    public class Expression
    {
        public string InputString;
        public string PolishString;
        private Matrix A = new Matrix();
        private Matrix B = new Matrix();
        private Matrix C = new Matrix();
        public Dictionary<char, Matrix> DictionaryWithSymbols = new Dictionary<char, Matrix>();
        Matrix Calculation = new Matrix();
        public Stack<char> StackForSolutin = new Stack<char>();
        public static Stack<char> ReverseExpression = new Stack<char>();

        public Expression()
        { }
        public Expression(string strok, Matrix A, Matrix B, Matrix C)
        {
            if (strok != null & A != null & B != null & C != null)
            {
                InputString = strok;
                //A = a;
                //A.Symbols = 'A';
                //B = b;
                //B.Symbols = 'B';
                //C = c;
                //C.Symbols = 'C';
                DictionaryWithSymbols.Add('A', A);
                DictionaryWithSymbols.Add('B', B);
                DictionaryWithSymbols.Add('C', C);

            }
            
            else
            {
                throw new NullReferenceException();
            }
            Console.WriteLine("Решение уравнения: {0}" , InputString);
        }

        public void TheFormationOfReversePlishNotation()
        {

            for (int i = 0; i < InputString.Length; i++)
            {
                if (Char.IsLetter(InputString[i]))
                {
                    PolishString += InputString[i];
                }
                else
                {
                    ProcessingOfBrackets(i);
                }
            }
            PullCharactersFromStack();




        }
        public void PullCharactersFromStack()
        {
            while (ReverseExpression.Count > 0)
            {
                PolishString += ReverseExpression.Pop();
            }
        }
        public byte GetPriority(char s)
        {
            switch (s)
            {
                case '(':
                case ')':
                    return 0;
                case '+':
                case '-':
                    return 1;
                case '*':
                    return 2;
                default:
                    return 3;
            }
        }
        public void OperationSelection(int i)
        {
            char Q = 'Q';
            char FirstSymbol = StackForSolutin.Pop();
            char SecondSymbol = StackForSolutin.Pop();
            var MatrixFromFirstSymbol = DictionaryWithSymbols[FirstSymbol];
            var MatrixFromSecondSymbol = DictionaryWithSymbols[SecondSymbol];
            if (DictionaryWithSymbols.ContainsKey(FirstSymbol) && DictionaryWithSymbols.ContainsKey(SecondSymbol))
            {

                switch (PolishString[i])
                {
                    case '+':
                        Calculation = Matrix.Sum(MatrixFromFirstSymbol, MatrixFromSecondSymbol);
                        break;
                    case '-':
                        Calculation = Matrix.Subtraction(MatrixFromSecondSymbol, MatrixFromFirstSymbol);
                        break;
                    case '*':
                        Calculation = Matrix.Multiplication(MatrixFromFirstSymbol, MatrixFromSecondSymbol);
                        break;
                }
                DictionaryWithSymbols[Q] = Calculation;
                Calculation.Symbols = Q;
                StackForSolutin.Push(Calculation.Symbols);
                int c = 60;
                Q = Convert.ToChar(c);
            }
            else
            {
                throw new Exception();
            }
        }
        public void GetSolution()
        {
            for (int i = 0; i < PolishString.Length; i++)
            {
                if (char.IsLetter(PolishString[i]))
                {
                    StackForSolutin.Push(PolishString[i]);
                }
                else
                {
                    if (StackForSolutin.Count > 1)
                    {
                        OperationSelection(i);
                    }
                    else
                    {
                        Calculation.OutputOfSolutionResults();
                    }
                }
            }
        }

        public void ProcessingOfBrackets(int i)
        {
            if (InputString[i] == '(')
            {
                ReverseExpression.Push(InputString[i]);
            }
            else
            {
                if (InputString[i] == ')')
                {
                    char Symbol = ReverseExpression.Pop();
                    while (Symbol != '(')
                    {
                        PolishString += Symbol.ToString();
                        Symbol = ReverseExpression.Pop();
                    }
                }
                else
                {
                    IdentificationOfPriorities(i);
                    ReverseExpression.Push(char.Parse(InputString[i].ToString()));
                }
            }
        }
        public void Decision()
        {
            TheFormationOfReversePlishNotation();
            GetSolution();
            Calculation.OutputOfSolutionResults();
        }

        public void IdentificationOfPriorities(int i)
        {
            if (ReverseExpression.Count > 0)
            {
                if (GetPriority(InputString[i]) <= GetPriority(ReverseExpression.Peek()))
                {
                    PolishString += ReverseExpression.Pop();
                }
            }

        }
    }
}
