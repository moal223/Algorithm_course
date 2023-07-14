using System;

namespace practiceSorte
{
    class Program
    {
        #region Insertion sort
        // best case => O(n^2)
        static void InsertionSort_v1(ref int[] arr, int len)
        {
            for(var i = 1; i < len; i++) // 2 8 5 6 9 7
            {
                for(var j = i-1; j >= 0; j--)
                {
                    if (arr[i] < arr[j])
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
        }

        // best case => O(n)
        static void InsertionSort_v2(ref int[] arr, int len)
        {
            for(var i = 1; i < len; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while(j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    --j;
                }
                arr[j + 1] = key;
            }
        }
        #endregion

        static void Main(string[] args)
        {
            int[] arr = new int[6] { 2, 8, 5, 6, 9, 7 };
            InsertionSort_v2(ref arr, 6);
            for (var i = 0; i < 6; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }
    }
}