using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 1:
                        Sort.DoBubbleSort();
                        break;
                    case 2:
                        Sort.DoQuickSort();
                        break;
                    default:
                        break;
                }
            } while (userInput != 5);
        }

        public static int DisplayMenu()
        {
            Console.WriteLine("Sorting");
            Console.WriteLine();
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Quick Sort");
            //Console.WriteLine("3. Quick Sort");
            Console.WriteLine("5. Exit");
            var result = Console.ReadLine();
            return Convert.ToInt32(result);
        }
    }
}
