using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Polska
{
    class FileIO
    {
        public static void Write(string output)
        {
            string writePath = @"output.txt";

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {

                sw.WriteLine(new string('-', 77));
                sw.WriteLine($"|Входной символ|               Тетрада              |         Стек          |");
                sw.WriteLine($"|              |Операция|Операнд1|Операнд2|Результат|                       |");
                sw.WriteLine(new string('-', 77));

                var stack = new Stack<string>();

                int i = 1;

                foreach (char c in output)
                {
                    string stk = String.Empty;
                    string a = String.Empty;
                    string b = String.Empty;

                    if (Char.IsDigit(c) || Char.IsLetter(c))
                    {
                        stack.Push(c.ToString());

                        foreach (string chr in stack.ToArray().Reverse())
                        {
                            stk += $"{chr}|";
                        }

                        sw.WriteLine("|{0,14}|{1,8}|{2,8}|{3,8}|{4,9}|{5,24}", c, null, null, null, null, stk);
                        sw.WriteLine(new string('-', 77));
                    }

                    if (c == '+' || c == '-' || c == '*' || c == '/')
                    {
                        if (stack.Count >= 1)
                        {
                            if (stack.Count > 0)
                            {
                                a = stack.Pop();
                            }

                            if (stack.Count > 0)
                            {
                                b = stack.Pop();
                            }

                            stack.Push($"T{i}");

                            var stk2 = String.Empty;

                            foreach (string chr in stack.ToArray().Reverse())
                            {
                                stk2 += $"{chr}|";
                            }

                            sw.WriteLine("|{0,14}|{1,8}|{2,8}|{3,8}|{4,9}|{5,24}", c, c.ToString(), b.ToString(), a.ToString(), $"T{i}", stk2);
                            sw.WriteLine(new string('-', 77));

                            i++;
                        }
                    }
                }

            }
        }

    }
}
