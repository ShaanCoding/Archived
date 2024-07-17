using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scientific_Calculator
{
    class Solver
    {
        public static double solveValue(string expression)
        {
            List<string> token = Tokenize(expression);
            List<string> RPN = GetRPN(token);
            return solver(RPN);
        }

        public static List<string> Tokenize(string input)
        {
            List<string> TokenResult = new List<string>();
            input = Regex.Replace(input, @"\s+", "");
            string numberString = "";
            foreach (char c in input)
            {
                if (Char.IsLetter(c))
                {
                    numberString += c;
                }
                else
                {
                    TokenResult.Add(numberString);
                    numberString = "";
                    TokenResult.Add(c.ToString());
                }
            }
            return TokenResult;
        }

        static List<string> GetRPN(List<string> token)
        {
            Stack<string> s = new Stack<string>();
            List<string> PostFix = new List<string>();

            Console.Write("\nEnter your expression: ");
            try
            {
                ConvertToPostFix(token, s, ref PostFix);

                Print(PostFix);
                return PostFix;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Invalid expression");
                return null;
            }
        }
        static void ConvertToPostFix(List<string> symbols, Stack<string> s, ref List<string> PostFix)
        {
            int n;
            foreach (string c in symbols)
            {
                if (int.TryParse(c.ToString(), out n))
                {
                    PostFix.Add(c);
                }
                if (c == "(") s.Push(c);
                if (c == ")")
                {
                    while (s.Count != 0 && s.Peek() != "(")
                    {
                        PostFix.Add(s.Pop());
                    }
                    s.Pop();
                }
                if (IsOperator(c))
                {
                    while (s.Count != 0 && Priority(s.Peek()) >= Priority(c))
                    {
                        PostFix.Add(s.Pop());
                    }
                    s.Push(c);
                }
            }
            while (s.Count != 0)
            {
                PostFix.Add(s.Pop());
            }
        }
        static int Priority(string c)
        {
            if (c == "^")
            {
                return 3;
            }
            else if (c == "*" || c == "/")
            {
                return 2;
            }
            else if (c == "+" || c == "-")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        static bool IsOperator(string c)
        {
            if (c == "+" || c == "-" || c == "*" || c == "/" || c == "^")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Print(List<string> PostFix)
        {
            for (int i = 0; i < PostFix.Count; i++)
            {
                Debug.Write("{0} ", PostFix[i]);
            }
        }

        public static double solver(List<string> token)
        {
            Console.WriteLine("Welcome to reverse polish notation calculator");

            Stack<double> stack = new Stack<double>();
            for (int i = 0; i < token.Count; i++)
            {
                if (double.TryParse(token[i], out double n))
                {
                    stack.Push(Convert.ToInt32(token[i]));
                }
                else if (token[i] == "^" || token[i] == "*" || token[i] == "/" || token[i] == "+" || token[i] == "-")
                {
                    double rightside = stack.Pop();
                    double leftside = stack.Pop();
                    double answer;
                    switch (token[i])
                    {
                        case "^":
                            answer = Math.Pow(leftside, rightside);
                            break;
                        case "*":
                            answer = leftside * rightside;
                            break;
                        case "/":
                            answer = leftside / rightside;
                            break;
                        case "+":
                            answer = leftside + rightside;
                            break;
                        case "-":
                            answer = leftside - rightside;
                            break;
                        default:
                            answer = 0;
                            Console.WriteLine("ERROR");
                            break;
                    }
                    stack.Push(answer);
                }
            }
            return stack.Pop();
        }
    }
}
