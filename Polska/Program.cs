using System;

namespace Polska
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] input = { };

            bool inputCorrect = false;

            while (inputCorrect == false)
            {
                Console.Write("Введите выражение: ");

                input = Console.ReadLine().ToCharArray();

                for (int i = 0; i < input.Length - 1; i++)
                {
                    if (input[i].Equals(input[i + 1]) && !input[i].Equals('(') && !input[i].Equals(')'))
                    {
                        inputCorrect = false;
                        break;
                    }
                    else
                    {
                        inputCorrect = true;
                    }
                }
            }

            string output = Algorithm.Сalculate(input);

            FileIO.Write(output);
            ConsoleIO.Write(output);

            Console.ReadKey();
        }
    }
}
