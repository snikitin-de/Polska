using System;
using System.Collections.Generic;
using System.Linq;

namespace Polska
{
    class Algorithm
    {
        public static string Сalculate(char[] input)
        {
            string output = String.Empty;

            var stack = new Stack<char>();

            foreach (char symbol in input)
            {
                if (Char.IsDigit(symbol) || Char.IsLetter(symbol))
                {
                    output += symbol;
                }

                if (symbol == '+' || symbol == '-' || symbol == '*' || symbol == '/')
                {
                    if (stack.Count != 0)
                    {
                        if (Priority(symbol) > Priority(stack.Peek()))
                        {
                            stack.Push(symbol);
                        }
                        else if (Priority(symbol) <= Priority(stack.Peek()))
                        {
                            while (stack.Count != 0 && Priority(symbol) <= Priority(stack.Peek()))
                            {
                                output += stack.Pop();
                            }

                            stack.Push(symbol);
                        }
                    }
                    else
                    {
                        stack.Push(symbol);
                    }
                }

                if (symbol == '(')
                {
                    stack.Push(symbol);
                }

                if (symbol == ')')
                {
                    while (stack.Peek() != '(')
                    {
                        output += stack.Pop();
                    }

                    stack.Pop();
                }
            }

            foreach (char chr in stack)
            {
                output += chr;
            }

            return output;
        }

        private static int Priority(char operation)
        {
            switch (operation)
            {
                case '(': return 1;
                case '-':
                case '+': return 2;
                case '/':
                case '*': return 3;
            }

            return 0;
        }
        private static string ReverseString(string s)
        {
            return new string(s.ToCharArray().Reverse().ToArray());
        }
    }
}
