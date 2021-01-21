using System;

namespace ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            // fizzbuzz iterative
            FB.DoIterative(100);

            // fizzbuzz recursive
            FB.DoRecursive(1, 100);
        }
    }
}
