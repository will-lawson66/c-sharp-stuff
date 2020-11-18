using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_stuff
{
    public class FB
    {
        public static string FizzBuzz(int n)
        {
            if (n % 5 == 0 && n % 3 == 0)
            {
                return "FizzBuzz";
            }
            else if (n % 5 == 0)
            {
                return "Buzz";
            }
            else if (n % 3 == 0)
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
