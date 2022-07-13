using System;
using System.Collections.Generic;
using System.Text;

namespace Sort
{
    public class Sort
    {
        public static void IntArrayGenerate(int[] data, int randomSeed)
        {
            Random r = new Random(randomSeed);
            for (int i = 0; i < data.Length; i++)
                data[i] = r.Next();
        }

        public static void DoBubbleSort()
        {
            Console.WriteLine("begin bubble sort");
            var data = new int[]
            {
                3, 6, 1, 9, 7, 5, 4, 2, 5, 8
            };
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + "");
            }
            Console.ReadLine();
            BubbleSort(data);
            Console.WriteLine("\nbubble sort:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + ", ");
            }

        }

        public static void Exchange(int[] data, int m, int n)
        {
            var temp = data[m];
            data[m] = data[n];
            data[n] = temp;
        }

        public static void BubbleSort(int[] data)
        {
            int i, j;
            int n = data.Length;

            for (i = n - 1; i > 0; i--)
            {
                for (j = 0; j < i; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        Exchange(data, j, j + 1);
                        for (int t = 0; t < data.Length; t++)
                        {
                            Console.Write(data[t] + ", ");
                        }
                        Console.ReadLine();
                    }
                }
            }
        }

        public static void DoQuickSort()
        {
            int[] data = new int[]{2, 9, 6, 8, 7, 4, 1, 24, 11, 29, 15, 22, 31, 14, 10, 5};
            //IntArrayGenerate(data, 7);
            QuickSort(data, 0, data.Length - 1);
        }

        public static int Partition(int[] data, int left, int right)
        {
            Console.WriteLine("Partitioning array");
            var pivot = data[(left + right) / 2];
            while (true)
            {
                while (data[left] < pivot)
                {
                    Console.WriteLine("move left");
                    left++;
                    DisplayArray(data, left, right, pivot);
                }

                while (pivot < data[right])
                {
                    Console.WriteLine("move right");
                    right--;
                    DisplayArray(data, left, right, pivot);
                }


                if (left < right)
                {
                    Console.WriteLine("left < right");
                    Exchange(data, left, right);

                    Console.WriteLine("exchange: ");
                    DisplayArray(data, left, right, pivot);


                    Console.WriteLine("left++ ");
                    left++;

                    Console.WriteLine("right-- ");
                    right--;

                    DisplayArray(data, left, right, pivot);

                }
                else
                {
                    Console.WriteLine("break and return {0} as new pivot", right);
                    return right;
                }
            }
        }

        public static void QuickSort(int[] data, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(data, left, right);
                Console.WriteLine("New pivot = {0}", pivot);
                
                if (pivot > 1)
                {
                    Console.WriteLine("Pivot: {0} > 1", pivot);
                    QuickSort(data, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    Console.WriteLine("Pivot + 1: {0} < right", pivot + 1);
                    QuickSort(data, pivot + 1, right);
                }
            }
            Console.WriteLine("Sorting complete");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
        }

        public static void DisplayArray(int[] data, int left, int right, int pivot)
        {
            Console.WriteLine("data: ");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("left: {0} left data: {1}", left, data[left]);
            Console.WriteLine("right: {0} right data: {1}", right, data[right]);
            Console.WriteLine("pivot data: {0}", pivot);
            Console.ReadLine();
        }
    }
}
