using System;

namespace ControlFlow
{
    public class FB
    {
        public static string FizzBuzz(int n)
        {
            if (n % 5 == 0 && n % 3 == 0)
            {
                return "FizzBuzz";
            }
            if (n % 5 == 0)
            {
                return "Buzz";
            }
            if (n % 3 == 0)
            {
                return "Fizz";
            }

            return n.ToString();
        }

        public static void DoIterative(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }

            Console.ReadLine();
        }

        public static void DoRecursive(int start, int end)
        {
            if (start <= end)
            {
                Console.WriteLine(FizzBuzz(start));
                DoRecursive(++start, end);
            }

            Console.ReadLine();
        }
    }
}
