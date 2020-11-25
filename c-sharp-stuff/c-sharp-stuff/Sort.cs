using System;
using System.Collections.Generic;
using System.Text;

namespace c_sharp_stuff
{
    public class Sort
    {
        public static void IntArrayGenerate(int[] data, int randomSeed)
        {
            Random r = new Random(randomSeed);
            for (int i = 0; i < data.Length; i++)
                data[i] = r.Next();
        }

        public static void Do()
        {

            //var data = new int[10];
            //var seed = 12;
            //IntArrayGenerate(data, seed);

            //Console.WriteLine("raw data:");
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Console.WriteLine(data[i]);
            //}

            //BubbleSort(data);
            //Console.WriteLine("bubble sort:");
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Console.WriteLine(data[i]);
            //}
            var data = new int[]
            {
                3, 6, 1, 9, 7, 5, 4, 2, 5, 8
            };
            //IntArrayGenerate(data, seed);
            QuickSort(data);
            Console.WriteLine("\nquick sort:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i] + "");
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
                    }
                }
            }
        }

        public static void QuickSort(int[] data)
        {
            QuickSort(data, 0, data.Length - 1);
        }

        public static void QuickSort(int[] data, int inLeft, int inRight)
        {
            int left, right, pivotPosition, pivot;
            left = inLeft;
            right = inRight;
            pivotPosition = inRight;
            pivot = data[inRight]; //pivot

            
            while (true)
            {
                while (data[left] < pivot)
                    left++;
                while (pivot < data[right])
                    right--;
                if (left <= right)
                {
                    Console.WriteLine();
                    Exchange(data, left, right);
                    for (int i = 0; i < data.Length; i++)
                    {
                        Console.Write(data[i] + "");
                    }
                    left++;
                    right--;
                }
                if (left > right)
                    break;
            }
            if (inLeft < right)
                QuickSort(data, inLeft, right);
            if (left < inRight)
                QuickSort(data, left, inRight);
        }
    }
}
